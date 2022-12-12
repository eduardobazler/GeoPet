//using System;
//using System.Drawing;
//using GeoPet.Models;
//using QRCoder;

//namespace GeoPet.Services
//{
//    public class QrCodeGenerator
//    {

//        public Bitmap GenerateImage(GeoLocalization localization)
//        {
//            var qrGenerator = new QRCodeGenerator();
//            var qrCodeData = qrGenerator.CreateQrCode(localization, QRCodeGenerator.ECCLevel.Q);
//            var qrCode = new QRCode(qrCodeData);
//            var qrCodeImage = qrCode.GetGraphic(10);
//            return qrCodeImage;
//        }

//        public byte[] GenerateByteArray(GeoLocalization localization)
//        {
//            var image = GenerateImage(localization);
//            return ImageToByte(image);
//        }

//        private byte[] ImageToByte(Image img)
//        {
//            using var stream = new MemoryStream();
//            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
//            return stream.ToArray();

//        }
//    }
//}

