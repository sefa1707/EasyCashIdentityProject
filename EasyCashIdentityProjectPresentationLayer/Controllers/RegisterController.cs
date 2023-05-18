using EasyCashIdentityProjectDtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProjectEntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;


namespace EasyCashIdentityProjectPresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
           if(ModelState.IsValid)
            {
                Random random=new Random();
                int code;
                code = random.Next(100000, 1000000);


                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "aaa",
                    District = "aaa",
                    ImageUrl = "aaa",
                    ConfirmCode = code
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if(result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "projedemolarim@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirebilmek için onay kodunuz : "+code;
                    mimeMessage.Body=bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";
                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com",587,false);
                    client.Authenticate("projedemolarim@gmail.com", "uxeoxppblaxoxpsn");
                    client.Send(mimeMessage);
                    client.Disconnect(true);


                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}



//şifre en az 6 karakter olmalı
//şifre en az 1 küçük harf
//şifre en az 1 büyük harf
//şifre en az 1 sembol
//şifre en az 1 sayı içermeli
