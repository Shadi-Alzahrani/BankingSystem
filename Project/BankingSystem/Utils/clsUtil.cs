using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms.DataVisualization.Charting;

namespace BankingSystem.Utils
{
    public  class clsUtil
    {

        public static async Task ExportDataTableToPdf(DataTable dt, string title, string fileName)
        {
            string folderPath = @"C:\\Reports\\";

            try
            {
                // 1️⃣ إنشاء المجلد إذا لم يكن موجود
                Directory.CreateDirectory(folderPath);

                // 2️⃣ تحديد مسار الملف الكامل
                string filePath = Path.Combine(folderPath, fileName);

                // 3️⃣ التأكد أن DataTable ليس فارغ
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("theres No Data To Extract To Pdf ", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 4️⃣ إنشاء مستند PDF
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // 5️⃣ إضافة عنوان
                
                Paragraph header = new Paragraph(title, FontFactory.GetFont("Arial", 16));
                header.Alignment = Element.ALIGN_CENTER;
                header.SpacingAfter = 20;
                document.Add(header);

                // 6️⃣ إنشاء الجدول بعدد أعمدة DataTable
                PdfPTable table = new PdfPTable(dt.Columns.Count);
                table.WidthPercentage = 100;

                // 7️⃣ إضافة رؤوس الأعمدة
                foreach (DataColumn column in dt.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                // 8️⃣ إضافة الصفوف
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(item.ToString(), FontFactory.GetFont("Arial", 11)));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }
                }

                document.Add(table);
                document.Close();

                // 9️⃣ فتح الملف مباشرة بعد الإنشاء
                if (File.Exists(filePath))
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    };
                    Process.Start(psi);
                }
                else
                {
                    MessageBox.Show("PDF file was not created!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public static void LogUiExceptionToWinEventLog(Exception ex)
        {
            string SourceName = "BankingSystem.Ui.Layer";

            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");

            }
            EventLog.WriteEntry(SourceName, $"an Error Occurd Becase :{ex.Message} ", EventLogEntryType.Error);

        }

        private static  bool _CreateDirectary(string DirName)
        {
            
            string BasePath = "C:\\Users\\shadi\\Desktop\\BankingSystem\\Project\\";
            string DirPath = Path.Combine(BasePath, DirName);
            try
            {
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                return true;
            }
            catch(Exception ex)
            {
                LogUiExceptionToWinEventLog (ex);
                return false;
            }

            return false;
        }

        private  static string _GenrateGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
       
        private static   string  _ChangeImageNameToGuid( string ImageName)
        {
            string File = ImageName;
            FileInfo FileInfo = new FileInfo(File);

            return  _GenrateGuid()+FileInfo.Extension;
        }
        
        public static bool CopeImageToClientImageFolder( ref string SourceImage)
        {
            string BaseDir = "C:\\Users\\shadi\\Desktop\\BankingSystem\\Project\\ClientImages\\";
            try
            {
               

                if (!_CreateDirectary(BaseDir))
                {
                    return false;
                }

                string ImageAfterCope = BaseDir + _ChangeImageNameToGuid(SourceImage);

               


                File.Copy(SourceImage, ImageAfterCope,true);
                SourceImage = ImageAfterCope;

                return true;
            }
            catch (Exception ex)
            {
                clsUtil.LogUiExceptionToWinEventLog (ex);
                return false;
            }

            return false;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }


        public static bool SaveUserAccountInWindowsRegistry(string UserName,string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\BankingProject";
            string UserLoginInfo = "User Info";
            string UserLoginData = $"{UserName}#//#{Password} ";

            try
            {
                Registry.SetValue(KeyPath, UserLoginInfo, UserLoginData);
                

            }
            catch (Exception ex)
            {
               clsUtil.LogUiExceptionToWinEventLog(ex);
                return false;
            }
            return true;
        }
    
     public static string GetUserInfoFromWindowsRegistry()
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\BankingProject";
            string valueName = "User Info";

            
            try
            {
                string Value = Registry.GetValue(KeyPath, valueName, null) as string;

                if (Value != null)
                {
                   return Value;

                }
                else
                {
                    return null;


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Error occure while retriving data from  the registery becase : {ex.Message}");
            }
            return null;
        }
      public   static string EncryptPasswordUsingHashing(string Password)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));


                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static void CreateBarChart(Chart chartControl,
                                            string bar1Name, double bar1Value,
                                            string bar2Name, double bar2Value,
                                            string bar3Name, double bar3Value)
        {
            // تنظيف كل شيء قبل الرسم
            chartControl.Series.Clear();
            chartControl.ChartAreas.Clear();
            chartControl.Titles.Clear();
            chartControl.Legends.Clear();
            chartControl.BackColor = Color.White;

            // إعداد منطقة الرسم
            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;

            // عكس الاتجاه (من اليمين إلى اليسار)
            area.AxisX.IsReversed = true;

            // تنسيق المحاور
            area.AxisX.MajorGrid.Enabled = false; // إلغاء الخطوط الأفقية
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LineColor = Color.Transparent;
            area.AxisY.LineColor = Color.Transparent;

            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9);
            area.AxisY.LabelStyle.ForeColor = Color.DimGray;
            area.AxisX.LabelStyle.ForeColor = Color.Black;

            area.AxisY.Title = "Count";
            area.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
            area.AxisY.TitleForeColor = Color.Gray;

            chartControl.ChartAreas.Add(area);

            // إنشاء السلسلة
            Series series = new Series("Statistics");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
            series.LabelForeColor = Color.Black;

            // ألوان ناعمة وجميلة
            Color[] colors = new Color[]
            {
        Color.FromArgb(72, 149, 239),  // أزرق ناعم
        Color.FromArgb(0, 204, 153),   // أخضر نعناعي
        Color.FromArgb(255, 159, 64)   // برتقالي هادئ
            };

            // إضافة القيم
            series.Points.AddXY(bar1Name, bar1Value);
            series.Points.AddXY(bar2Name, bar2Value);
            series.Points.AddXY(bar3Name, bar3Value);

            // تعيين الألوان لكل عمود
            for (int i = 0; i < series.Points.Count; i++)
                series.Points[i].Color = colors[i];

            chartControl.Series.Add(series);

            // العنوان الجميل
            Title title = new Title("Transaction OverView",
                Docking.Top, new System.Drawing.Font("Segoe UI", 15, FontStyle.Bold), Color.FromArgb(83, 145, 140));
            chartControl.Titles.Add(title);

            // إزالة الإطار الرمادي حول الرسم
            chartControl.BorderlineWidth = 0;
            chartControl.BorderlineColor = Color.Transparent;
        }
    }

}
    
    

