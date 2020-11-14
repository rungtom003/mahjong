
function Validate() {
    $.ajax(
            {
                type: "POST",
                url: '/Mahjong/Login',
                data: {
                    Username: $('#username').val(),
                    Password: $('#password').val()
                },
                error: function (result) {
                    alert("There is a Problem, Try Again!");
                },
                success: function (result) {
                    console.log(result);
                    if (result.status == true) {                      
                        window.location.href = "/Mahjong/Index";
                    }
                    else {
                        Swal.fire(
                            'ล็อคอิน',
                            '' + result.message+'',
                            'warning'
                        )
                    }
                }
            });
}
$("#btnlogin").click(function (e) {
    e.preventDefault();
    Validate();
})





