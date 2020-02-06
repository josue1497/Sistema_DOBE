$(function() {
    $('#acceder').on('click', function() {
        var usuario = $('#usuario').val();
        var contraseña = $('#contraseña').val();
        var url = 'php/inicio_sesion.php';
        var validaciondecampos = usuario.length * contraseña.length;
        if (validaciondecampos > 0) {
            $.ajax({
                type: 'POST',
                url: url,
                data: 'usuario=' + usuario + '&contraseña=' + contraseña,
                success: function(comparacionval) {
                    if (comparacionval == 'usuario') {
                        alert("Los datos introducidos Son incorrectos.");
                        return false;
                    } else if (comparacionval == 'contraseña') {
                        alert("Los datos introducidos son incorrectos.");
                        return false;
                    } else if (comparacionval == 'Admin') {
                        document.location.href = 'vistas/admin/princ_admin.php';
                    } else if (comparacionval == 'Dobe') {
                        document.location.href = 'vistas/dobe/princ_dobe.php';
                    } else if (comparacionval == 'Admintvo') {
                        document.location.href = 'vistas/admintvo/princ_admintvo.php';
                    } else if (comparacionval == 'Estudiante') {
                        document.location.href = 'vistas/estudiante/princ_estudiante.php';
                    } else if (comparacionval == 'NOHM') {
                        document.location.href = 'HMedico.php';
                    }
                }
            });
            return false;
        } else {
            alert("Ningun campo puede estar vacio.");
            return false;
        }
        return false;
    });
});