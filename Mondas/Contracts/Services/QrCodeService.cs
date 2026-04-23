using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.Drawing;

namespace Mondas.Contracts.Services
{
    public sealed class QrCodeService
    {
        public Bitmap GenerateQrBitmap(string payload, int pixelsPerModule)
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q))
            using (var code = new QRCode(data))
            {
                return code.GetGraphic(pixelsPerModule);
            }
        }

    }
}