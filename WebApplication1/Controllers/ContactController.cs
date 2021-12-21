using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : ApiController
    {
        Contact[] contacts = new Contact[] {
            new Contact(){ ID=1,Age=20,Birthday=Convert.ToDateTime("1988-07-25"),Name="嗷叫",Sex="男"},
            new Contact(){ ID=2,Age=18,Birthday=Convert.ToDateTime("1988-07-3"),Name="阿拉斯",Sex="女"},
            new Contact(){ ID=3,Age=1,Birthday=Convert.ToDateTime("1988-07-26"),Name="网袜",Sex="女"},
            new Contact(){ ID=4,Age=4,Birthday=Convert.ToDateTime("1988-07-5"),Name="哈子",Sex="男"}
        };

        public IEnumerable<Contact> GetListAll()
        {
            return contacts;
        }

        public Contact GetContactByID(int id)
        {
            Contact contact = contacts.FirstOrDefault<Contact>(item => item.ID == id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return contact;
        }

        public IEnumerable<Contact> GetListBySex(string sex)
        {
            return contacts.Where(item => item.Sex == sex);
        }

    }

}
