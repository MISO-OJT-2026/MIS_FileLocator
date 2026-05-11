window.misQr = window.misQr || {};

window.misQr.copyTextFallback = function (text) {
    const ta = document.createElement('textarea');
    ta.value = text;
    ta.setAttribute('readonly', '');
    ta.style.position = 'absolute';
    ta.style.left = '-9999px';
    document.body.appendChild(ta);
    ta.select();
    document.execCommand('copy');
    document.body.removeChild(ta);
};

window.misQr.printQrLabel = async function (title, dataUrl, url, locationPath) {
    // Note: 'url' parameter is intentionally not displayed in the label
    // The QR code itself encodes the URL — no need to show it as text
    const blob = await (await fetch(dataUrl)).blob();
    const blobUrl = URL.createObjectURL(blob);

    const w = window.open('', '_blank');
    if (!w) return;

    const loc = locationPath ? `<p style="font-size:14px;color:#444;margin:8px 0;">${escapeHtml(locationPath)}</p>` : '';

    w.document.write(`<!DOCTYPE html><html><head><title>${escapeHtml(title)}</title>
<style>
  body { font-family: system-ui, sans-serif; text-align: center; padding: 40px; }
  h1 { font-size: 24px; margin: 0; }
  img { 
      width: 300px; height: 300px; 
      display: block; margin: 20px auto;
      image-rendering: pixelated;
      -webkit-print-color-adjust: exact !important; 
      print-color-adjust: exact !important; 
  }
  .url { font-size: 13px; color: #333; margin-top: 10px; }
  .print-btn {
      margin-top: 24px;
      padding: 12px 32px;
      font-size: 16px;
      font-weight: 600;
      background: #0e1824;
      color: #fff;
      border: none;
      border-radius: 8px;
      cursor: pointer;
      display: inline-flex;
      align-items: center;
      gap: 8px;
  }
  .print-btn:hover { background: #1a3a52; }
  @media print { .print-btn { display: none; } }
</style></head><body>
  <h1>${escapeHtml(title)}</h1>
  ${loc}
  <img src="${blobUrl}" id="qrImg" />

  <br/>
  <button class="print-btn" onclick="window.print()">🖨️ Print</button>
  <script>
    document.getElementById('qrImg').onload = () => {
        URL.revokeObjectURL('${blobUrl}');
    };
  </script>
</body></html>`);

    w.document.close();
};

function escapeHtml(s) {
    if (s == null) return '';
    return String(s)
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;');
}
