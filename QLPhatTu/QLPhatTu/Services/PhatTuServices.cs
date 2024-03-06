using QLPhatTu.Entities;
using QLPhatTu.IServices;
using System.Net.Mail;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using Microsoft.Extensions.Configuration;

namespace QLPhatTu.Services
{
    public class PhatTuServices : IPhatTuServices
    {
        private readonly AppDbContext dbContext;
        private readonly IConfiguration _configuration;
        public PhatTuServices(IConfiguration configuration)
        {
            dbContext = new AppDbContext();
            _configuration = configuration;
        }
        Random random = new Random();
        public static void GuiMaXacNhan(string email, string code)
        {
            // Cấu hình thông tin email
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "emperor2002fix@gmail.com";
            string smtpPassword = "jhqmmixrlxircikh"; // mật khẩu ứng dụng của em lấy trên cài đặt gmail

            // Tạo đối tượng MailMessage
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(smtpUsername); // Thêm dòng này để chỉ định địa chỉ email người gửi
            mailMessage.To.Add(email);
            mailMessage.Subject = "Mã xác nhận";
            mailMessage.Body = "Mã xác nhận của bạn là: " + code;

            // Cấu hình đối tượng SmtpClient
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;

            try
            {
                // Gửi email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Mã xác nhận đã được gửi thành công.");// cái này em test trên màn console
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gửi mã xác nhận không thành công. Lỗi: " + ex.Message);
            }
        }
        public bool KiemTraTaiKhoan(string tenTaiKhoan)
        {
            // Kiểm tra tính duy nhất của tên tài khoản
            var kiemTra = dbContext.PhatTu.FirstOrDefault(tk => tk.TenTaiKhoan == tenTaiKhoan);

            if (kiemTra != null)
            {
                return false; // Tên tài khoản đã tồn tại
            }

            return true; // Tên tài khoản là duy nhất
        }
        public PhatTu DangKyTaiKhoan(PhatTu phatTu)//Dang ki tai khoan
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                if(KiemTraTaiKhoan(phatTu.TenTaiKhoan) == true)
                {
                    var dsXacNhan = phatTu.XacNhanEmail;
                    phatTu.XacNhanEmail = null;
                    phatTu.NgayCapNhat = DateTime.Now;
                    phatTu.NgayHoanTuc = DateTime.Now.AddYears(5); // hoàn tục trong 5 năm
                    dbContext.Add(phatTu);
                    dbContext.SaveChanges();
                    foreach (var chiTiet in dsXacNhan)
                    {
                        chiTiet.PhatTuId = phatTu.Id;
                        chiTiet.ThoiGianHetHan = DateTime.Now.AddDays(1); //em test thời gian hêt hạn trong 1 ngày
                        string Code = random.Next(100000, 999999).ToString();
                        chiTiet.MaXacNhan = Code;
                        GuiMaXacNhan(phatTu.Email, chiTiet.MaXacNhan);
                        chiTiet.DaXacNhan = "Chưa Kích Hoạt";
                        dbContext.Add(chiTiet);
                        dbContext.SaveChanges();
                    }
                    dbContext.SaveChanges();
                    trans.Commit();
                    return phatTu;
                }
                else
                {
                    throw new Exception("Tên tài khoản bị trùng!");
                }
            }
        }
        public bool XacThucDangKyTaiKhoan(string tenTaiKhoan)
        {
            var canTim = dbContext.PhatTu.FirstOrDefault(x=>x.TenTaiKhoan == tenTaiKhoan);
            if (canTim != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DangNhap(string tenTaiKhoan, string matKhau)
        {
            var canTim = dbContext.PhatTu.SingleOrDefault(x=>x.TenTaiKhoan== tenTaiKhoan 
                                                        && x.MatKhau == matKhau);
            if(canTim != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public bool GuiMail(string tenTaiKhoan, string Code)
        {
            var canTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan);
            if (canTim != null)
            {
                GuiMaXacNhan(canTim.Email, Code);
                return true;  
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<PhatTu> GetDSPhatTu(string? tenTaiKhoan = null, string? email = null, string? gioiTinh = null)
        {
            var query = dbContext.PhatTu.AsQueryable();
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    query = query.Where(x => x.TenTaiKhoan.ToLower().Contains(keyword.ToLower())
            //                        || x.Email.ToLower().Contains(keyword.ToLower())
            //                        || x.GioiTinh.ToLower().Contains(keyword.ToLower()));
            //}
            if (!string.IsNullOrEmpty(tenTaiKhoan))
            {
                query = query.Where(x => x.TenTaiKhoan.ToLower().Contains(tenTaiKhoan.ToLower()));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            }
            if (!string.IsNullOrEmpty(gioiTinh))
            {
                query = query.Where(x => x.GioiTinh == gioiTinh);
            }
            return query;
        }

        public string GenerateToken(string tenTaiKhoan)
        {
            var CanTim = dbContext.PhatTu.SingleOrDefault(x => x.TenTaiKhoan == tenTaiKhoan);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, CanTim.Id.ToString()),
                    new Claim(ClaimTypes.Name, CanTim.TenTaiKhoan),
                    new Claim(ClaimTypes.Email, CanTim.Email),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void SaveTokenToDatabase(string tenTaiKhoan, string token)
        {
            // Lưu mã thông báo vào cơ sở dữ liệu, ví dụ: sử dụng Entity Framework
            var user = dbContext.PhatTu.FirstOrDefault(u => u.TenTaiKhoan == tenTaiKhoan);
            if (user != null)
            {
                var canTim = dbContext.RefeshToken.FirstOrDefault(x=>x.PhatTuId == user.Id);
                if( canTim != null )
                {
                    canTim.ToKen = token;
                    canTim.ThoiGianHetHan = DateTime.UtcNow.AddDays(7);
                    dbContext.Update(canTim);
                    dbContext.SaveChanges();
                }
                else
                {
                    RefeshToken rt = new RefeshToken();
                    rt.ToKen = token;
                    rt.ThoiGianHetHan = DateTime.UtcNow.AddDays(7);
                    rt.PhatTuId = user.Id;
                    dbContext.Add(rt);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
