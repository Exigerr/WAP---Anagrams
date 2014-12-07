using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace anagramApp.Classes {
    public class Redirector {
        private HttpResponse _response = HttpContext.Current.Response;
        private HttpRequest _request = HttpContext.Current.Request;
        private HttpContextBase _context;

        public Redirector(HttpContextBase context) {
            _context = context;
        }

        public void Go() {
            string returnUrl = _request.Params["ReturnUrl"];
            if (String.IsNullOrEmpty(returnUrl)) {
                _response.Redirect("~");
            }
            else {
                _context.RedirectLocal(returnUrl);
            }
        }
    }
}