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

window.misQr.printQrLabel = function (title, dataUrl, url, locationPath) {
    const w = window.open('', '_blank');
    if (!w) return;
    const loc = locationPath ? `<p style="font-size:13px;color:#444;margin:8px 0 0 0;">${escapeHtml(locationPath)}</p>` : '';
    w.document.write(`<!DOCTYPE html><html><head><title>${escapeHtml(title)}</title>
<style>
  body { font-family: system-ui, Segoe UI, Roboto, sans-serif; text-align: center; padding: 24px; }
  h1 { font-size: 18px; margin: 0 0 12px 0; }
  img { width: 280px; height: 280px; image-rendering: pixelated; }
  .url { font-size: 11px; word-break: break-all; color: #333; margin-top: 12px; max-width: 400px; margin-left: auto; margin-right: auto; }
</style></head><body>
  <h1>${escapeHtml(title)}</h1>
  ${loc}
  <img src="${dataUrl}" alt="QR" />
  <p class="url">${escapeHtml(url)}</p>
</body></html>`);
    w.document.close();
    w.focus();
    w.print();
};

function escapeHtml(s) {
    if (s == null) return '';
    return String(s)
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;');
}
