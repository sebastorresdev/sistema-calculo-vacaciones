// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});

function confirmDelete(event, form) {
    // Evitar que el formulario se envíe automáticamente
    event.preventDefault();

    // Mostrar la alerta de SweetAlert2
    Swal.fire({
        title: "¿Estás seguro?",
        text: "¡No podrás revertir esto!",
        icon: "warning",
        showCancelButton: true,
        customClass: {
            confirmButton: 'btn btn-primary btn-lg mr-2',
            cancelButton: 'btn btn-danger btn-lg',
            loader: 'custom-loader',
        },
        confirmButtonText: "Sí, eliminar",
        cancelButtonText: "Cancelar"
    }).then((result) => {
        if (result.isConfirmed) {
            // Mostrar mensaje de éxito y enviar el formulario
            Swal.fire({
                title: "¡Eliminado!",
                text: "El registro ha sido eliminado.",
                icon: "success",
                timer: 1500, // Mostrar por 1.5 segundos
                showConfirmButton: false
            });

            // Enviar el formulario manualmente
            form.submit();
        }
    });

    return false; // Previene el envío inmediato del formulario
}