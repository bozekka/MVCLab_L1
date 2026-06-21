// Drobne usprawnienia UI. Formularz filtra wysyłany jest standardowo (GET).
// Auto-ukrywanie komunikatu flash po kilku sekundach.
document.addEventListener('DOMContentLoaded', function () {
    var flash = document.querySelector('.flash');
    if (flash) {
        setTimeout(function () {
            flash.style.transition = 'opacity .4s';
            flash.style.opacity = '0';
            setTimeout(function () { flash.remove(); }, 400);
        }, 4000);
    }
});

// Zamykanie dropdownu po kliknięciu poza nim
document.addEventListener('click', function (e) {
    var menus = document.querySelectorAll('.user-menu');
    menus.forEach(function (m) {
        if (!m.contains(e.target)) {
            var dd = m.querySelector('.user-dropdown');
            if (dd) dd.style.display = '';
        }
    });
});
