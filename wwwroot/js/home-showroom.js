// ── MIS File Locator – Home Showroom JS ──────────────────────────────────────

window.showroom = {

    animateCounter(elementId, target, duration = 1200) {
        const el = document.getElementById(elementId);
        if (!el) return;
        const start = performance.now();
        const update = (now) => {
            const elapsed = now - start;
            const progress = Math.min(elapsed / duration, 1);
            const eased = 1 - Math.pow(1 - progress, 3);
            el.textContent = Math.round(eased * target).toLocaleString();
            if (progress < 1) requestAnimationFrame(update);
        };
        requestAnimationFrame(update);
    },

    staggerCards(containerSelector, delay = 70) {
        const cards = document.querySelectorAll(containerSelector + ' .showroom-item');
        cards.forEach((card, i) => {
            card.style.opacity = '0';
            card.style.transform = 'translateY(32px) scale(0.94)';
            card.style.transition = 'none';
            setTimeout(() => {
                card.style.transition = 'opacity 0.4s ease, transform 0.4s ease';
                card.style.opacity = '1';
                card.style.transform = 'translateY(0) scale(1)';
            }, i * delay + 30);
        });
    },

    burst(x, y, color = '#5eb5f7') {
        for (let i = 0; i < 10; i++) {
            const p = document.createElement('div');
            const angle = (i / 10) * 2 * Math.PI;
            const dist = 40 + Math.random() * 30;
            p.style.cssText = `
                position:fixed;left:${x}px;top:${y}px;
                width:6px;height:6px;border-radius:50%;
                background:${color};pointer-events:none;z-index:9999;
                transition:transform 0.5s ease-out,opacity 0.5s ease-out;
                transform:translate(0,0) scale(1);opacity:1;`;
            document.body.appendChild(p);
            requestAnimationFrame(() => {
                p.style.transform = `translate(${Math.cos(angle)*dist}px,${Math.sin(angle)*dist}px) scale(0)`;
                p.style.opacity = '0';
            });
            setTimeout(() => p.remove(), 520);
        }
    },

    initParticles(canvasId) {
        const canvas = document.getElementById(canvasId);
        if (!canvas) return;
        const ctx = canvas.getContext('2d');
        let particles = [];
        const resize = () => { canvas.width = canvas.offsetWidth; canvas.height = canvas.offsetHeight; };
        resize();
        window.addEventListener('resize', resize);
        for (let i = 0; i < 28; i++) {
            particles.push({
                x: Math.random() * canvas.width, y: Math.random() * canvas.height,
                r: 1.5 + Math.random() * 2.5,
                dx: (Math.random() - 0.5) * 0.4, dy: (Math.random() - 0.5) * 0.4,
                alpha: 0.15 + Math.random() * 0.25
            });
        }
        const draw = () => {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            particles.forEach(p => {
                ctx.beginPath(); ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
                ctx.fillStyle = `rgba(94,181,247,${p.alpha})`; ctx.fill();
                p.x += p.dx; p.y += p.dy;
                if (p.x < 0 || p.x > canvas.width) p.dx *= -1;
                if (p.y < 0 || p.y > canvas.height) p.dy *= -1;
            });
            requestAnimationFrame(draw);
        };
        draw();
    }
};

// ── Carousel helpers ─────────────────────────────────────────────────────────

function _carouselState(trackId) {
    const track = document.getElementById(trackId);
    if (!track) return null;
    const slides = track.querySelectorAll('.carousel-slide');
    const current = parseInt(track.dataset.current || '0');
    return { track, slides, current, total: slides.length };
}

function _carouselApply(trackId, dotsId, idx) {
    const s = _carouselState(trackId);
    if (!s) return;
    const clamped = Math.max(0, Math.min(idx, s.total - 1));
    s.track.style.transform = `translateX(-${clamped * 100}%)`;
    s.track.dataset.current = clamped;

    const dots = document.querySelectorAll(`#${dotsId} .dot`);
    dots.forEach((d, i) => d.classList.toggle('active', i === clamped));
}

window.carouselNext = function(trackId, dotsId) {
    const s = _carouselState(trackId);
    if (!s) return;
    const next = (s.current + 1) % s.total;
    _carouselApply(trackId, dotsId, next);
};

window.carouselPrev = function(trackId, dotsId) {
    const s = _carouselState(trackId);
    if (!s) return;
    const prev = (s.current - 1 + s.total) % s.total;
    _carouselApply(trackId, dotsId, prev);
};

window.carouselGo = function(trackId, dotsId, idx) {
    _carouselApply(trackId, dotsId, idx);
};
