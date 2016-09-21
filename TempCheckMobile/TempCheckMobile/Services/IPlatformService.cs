using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Mobile;

namespace TempCheckMobile.Services
{
    public interface IPlatformService
    {
        MobileBarcodeScanner GetMobileBarcodeScanner();
    }
}
