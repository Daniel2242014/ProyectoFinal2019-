﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionLib;

namespace Instalador
{
    public partial class InstallerForm : Form
    {
        public InstallerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.Environment.OSVersion.Version.Major < 6 || (System.Environment.OSVersion.Version.Major == 6 && System.Environment.OSVersion.Version.Minor < 2))
            {
                MessageBox.Show("El SLTA sólo tiene funcionamiento verificado en Windows 7 y Windows 10, no aseguramos que funcione correctamente en otras versiones del sistema", "Sistema antigüo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\ODBC\\ODBCINST.INI"))
            {
                if (!rk.GetSubKeyNames().Contains("IBM INFORMIX ODBC DRIVER (64-bit)"))
                {
                    MessageBox.Show("Debe instalar el driver 64 bits de Informix para ODBC antes de instalar el SLTA", "Falta driver de ODBC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full"))
            {
                if (!rk.GetValueNames().Contains("Release") || (rk.GetValue("Release") as int?) < 461808)
                {
                    MessageBox.Show("Debe instalar .NET Framework 4.7.2 o mayor antes de instalar el SLTA", "Falta .NET Framework actualizado", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = keyBox.Text;
            BitMath.Matrix[] mats;
            try
            {
                mats = BitMath.Matrix.FromBase64(x);
            }
            catch (Exception)
            {
                MessageBox.Show("Clave inválida");
                return;
            }
            foreach (BitMath.Matrix m in mats)
            {
                Console.WriteLine(m);
            }
            var M1Mat = mats[0] * mats[1];
            var M2Mat = mats[2] * mats[3];
            var ExpectedM1 = new BitMath.Matrix(new Fractions.Fraction[][] { new Fractions.Fraction[] { 2, 19, 19 }, new Fractions.Fraction[] { 9, 18, 11 }, new Fractions.Fraction[] { 20, 11, 22 } });
            var ExpectedM2 = new BitMath.Matrix(new Fractions.Fraction[][] { new Fractions.Fraction[] { 19, 20 }, new Fractions.Fraction[] { 12, 1 } });
            if (M1Mat != ExpectedM1 || M2Mat != ExpectedM2)
            {
                MessageBox.Show("La clave ingresada es inválida!", "Clave errónea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Clave ingrezada";
                verifyButton.Enabled = false;
                button1.Enabled = false;
                packageBox.Enabled = true;
                appLbl.Enabled = true;
                installBtn.Enabled = true;
                smCheck.Enabled = true;
            }
        }

        private void installBtn_Click(object sender, EventArgs e)
        {
            if (packageBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe selecionar un elemento a insltalar");
                return;
            }
            var PFilesDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var InstallPath = System.IO.Path.Combine(PFilesDirectory, "Bit", "SLTA");
            if (!ConexionLib.FachadaRegistro.RegistrarPrograma(InstallPath))
            {
                MessageBox.Show("No se pudo registrar el programa, asegúrese de tener permisos de administrador");
            }
            if (MessageBox.Show($"El sistema se instalará en {InstallPath}, continuar?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            System.IO.Directory.CreateDirectory(InstallPath);
            byte[] packageBytes = Properties.Resources.Paquetes;
            string[] conditions;
            using (var packageStream = new System.IO.MemoryStream(packageBytes))
            {
                using (var zipArchive = new System.IO.Compression.ZipArchive(packageStream))
                {
                    var conditionsEntry = zipArchive.GetEntry("Conditions.txt");
                    using (var condition_stream = conditionsEntry.Open())
                    {
                        using (var streamReader = new System.IO.StreamReader(condition_stream))
                        {
                            conditions = streamReader.ReadToEnd().Split('\n');
                        }
                    }
                    conditions = conditions.Where(file =>
                    {
                        var parts = file.Split(':');
                        var appliesFor = parts[1].Contains('|') ? parts[1].Split('|') : new string[] { parts[1] };
                        bool v = appliesFor.Any(f => packageBox.CheckedItems.Cast<string>().Any(i => i.Trim() == f.Trim()));
                        return v;
                    }).ToArray();
                    progressBar1.Visible = true;
                    progressBar1.Maximum = conditions.Length;
                    progressBar1.Value = 0;
                    InstallList.Visible = true;
                    foreach (var file in conditions)
                    {
                        var fileName = file.Split(':')[0];
                        var fileEntry = zipArchive.GetEntry(fileName);
                        var fileStream = fileEntry.Open();
                        string path = System.IO.Path.Combine(InstallPath, fileName);
                        var outputStream = new System.IO.FileStream(path, System.IO.FileMode.Create);
                        using (var copyPromise = fileStream.CopyToAsync(outputStream))
                            copyPromise.Wait();
                        progressBar1.Value += 1;
                        InstallList.Items.Add(path);
                    }
                    if (smCheck.Checked)
                    {
                        var smPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
                        smPath = System.IO.Path.Combine(smPath, "Programs", "SLTA");
                        System.IO.Directory.CreateDirectory(smPath);
                        Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
                        dynamic shell = Activator.CreateInstance(t);
                        try
                        {
                            foreach (var f in conditions.Where(x => x.Split(':')[0].EndsWith(".exe")))
                            {
                                var iconPath = System.IO.Path.Combine(smPath, f.Split(':')[0].Split('.')[0]) + ".lnk";
                                var app = System.IO.Path.Combine(InstallPath, f.Split(':')[0]);
                                var lnk = shell.CreateShortcut(iconPath);
                                try
                                {
                                    lnk.TargetPath = app;
                                    lnk.IconLocation = app;
                                    lnk.Save();
                                    InstallList.Items.Add(iconPath);
                                }
                                finally
                                {
                                    Marshal.FinalReleaseComObject(lnk);
                                }
                            }
                        }
                        finally
                        {
                            Marshal.FinalReleaseComObject(shell);
                        }
                    }
                    if (MessageBox.Show("Instalado con éxito! ¿Desea abrir la configuración de red?", "Configuración de red", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        new ConfigurarRed(null).ShowDialog();
                    }
                }
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                var sr = new System.IO.StreamReader(open.FileName);
                var texto = sr.ReadToEnd();
                keyBox.Text = texto;
                sr.Close();
            }

        }


    }
}
