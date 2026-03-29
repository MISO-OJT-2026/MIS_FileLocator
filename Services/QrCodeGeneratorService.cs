using QRCoder;

namespace MIS_FileLocator.Services;

public class QrCodeGeneratorService
{
    public byte[] GeneratePngBytes(string content, int pixelsPerModule = 8)
    {
        using var qrGenerator = new QRCodeGenerator();
        var qrData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrData);
        return qrCode.GetGraphic(pixelsPerModule);
    }

    public string ToDataUrl(string content, int pixelsPerModule = 8)
    {
        var bytes = GeneratePngBytes(content, pixelsPerModule);
        return $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
    }
}
