function DeleteCourse(id) {
    swal({
        title: 'از حذف درس مطمئن هستید؟',
        text: "با حذف درس تمامی امتحان های مربوط به آن پاک میشود ",
        type: 'warning',
        showCancelButton: true,
        cancelButtonText: 'خیر',
        cancelButtonClass: 'btn btn-danger',
        showConfirmButton: true,
        confirmButtonText: 'بله',
        confirmButtonClass: 'btn btn-success'
    }, function (isConfirm) {
        if (isConfirm) {
            window.location.href = '/Course/Delete/' + id;
        }
        else {
            return false;
        }
    });
    return false;
}


function DeleteExam(id) {
    swal({
        title: 'از حذف امتحان مطمئن هستید؟',
        text: false,
        type: 'warning',
        showCancelButton: true,
        cancelButtonText: 'خیر',
        cancelButtonClass: 'btn btn-danger',
        showConfirmButton: true,
        confirmButtonText: 'بله',
        confirmButtonClass: 'btn btn-success'
    }, function (isConfirm) {
        if (isConfirm) {
            window.location.href = '/Exam/Delete/' + id;
        }
        else {
            return false;
        }
    });
    return false;
}

function openNav() {
    document.getElementById("mySidenav").style.width = "200px";
    document.getElementById("main").style.marginRight = "200px";
    document.getElementById("menuIcon").style.display = "none";
    document.getElementById("closeIcon").style.display = "block";
}

function closeNav(x) {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginRight = "0";
    document.getElementById("menuIcon").style.display = "block";
    document.getElementById("closeIcon").style.display = "none";

}



$(document).ready(function () {
    $("#Course").DataTable({

        "ajax": {
            "url": "/Course/GetDataTableCourse",
            "type": "Get",
            "datatype": "json"
        },
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },
        "columns": [
            { "data": "name" },
            {
                "data": "id",
                "render": function btn(data) {
                    var Updatebtn = "<a  onclick='UpdateCourse(" + data + ")' class='btn btn-primary d-inline-block'><i class='fa fa-edit'></i></a>";
                    var Deletebtn = "<form onclick='DeleteCourse(" + data + ")' class='d-inline-block'><button type='submit' class='btn btn-danger' onclick='return DeleteCourse(" + data + ")'><i class='fa fa-trash'></i> </button> </form>";

                    return Updatebtn + Deletebtn;


                }
            }
        ]
    })
})



function UpdateCourse(courseId) {

    window.location.href = '@Url.Action("Update", "Course")?id=' + courseId;

}

function DeleteCourse(courseId) {

    window.location.href = '@Url.Action("Delete", "Course")?id=' + courseId;

}
