//function DeleteCourse(id) {
//    console.log('test');
//    swal({
//        title: 'از حذف درس مطمئن هستید؟',
//        text: false,
//        type: 'warning',
//        showCancelButton: true,
//        cancelButtonText: 'خیر',
//        cancelButtonClass: 'btn btn-danger',
//        showConfirmButton: true,
//        confirmButtonText: 'بله',
//        confirmButtonClass: 'btn btn-success'
//    }, function (isConfirm) {
//        if (isConfirm) {
//            window.location.href = '/Course/Delete/'+ id;
//        }
//        else {
//            return false;
//        }
//    });
//    return false;
//}

//function DeleteExam(id) {
//    swal({
//        title: 'از حذف امتحان مطمئن هستید؟',
//        text: false,
//        type: 'warning',
//        showCancelButton: true,
//        cancelButtonText: 'خیر',
//        cancelButtonClass: 'btn btn-danger',
//        showConfirmButton: true,
//        confirmButtonText: 'بله',
//        confirmButtonClass: 'btn btn-success'
//    }, function (isConfirm) {
//        if (isConfirm) {
//            window.location.href = '/Exam/Delete/' + id;
//        }
//        else {
//            return false;
//        }
//    });
//    return false;
//}

$(function () {
    function close() {
        $('body').removeClass('has-active-menu');
        setTimeout(function () {
            $('.nav-slider').removeClass('toggling');
        }, 500);
    }

    function open() {
        $('body').addClass('has-active-menu');
        $('.nav-slider').addClass('toggling');
    }

    $('.nav-mask').click(close);
    $('.navbar-toggler').click(open);
});


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


$(document).ready(function () {
    $("#AllExamResult").DataTable({
        "ajax": {
            "url": "/TakeExam/AllExamResultsForAdminDataTable",
            "type": "Get",
            "datatype": "json"
        },
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },
        "columns": [
            { "data": "UserName" },
            { "data": "ExamName" },
            { "data": "CourseName" },
            { "data": "Score" },
            { "data": "DateTime" }
            
        ]
    })
})

function UpdateCourse(courseId) {

    window.location.href = '@Url.Action("Update", "Course")?id=' + courseId;

}

function DeleteCourse(courseId) {

    window.location.href = '@Url.Action("Delete", "Course")?id=' + courseId;

}










    document.getElementById('timer').innerHTML =
        0 + ":" +@Model.ExamDuration;
    startTimer();

    function startTimer() {
        var presentTime = document.getElementById('timer').innerHTML;
    var timeArray = presentTime.split(/[:]+/);
    var m = timeArray[0];
    var s = checkSecond((timeArray[1] - 1));
        if (s == 59) {m = m - 1}

    if (m == 0 && s == 0) {

        $("#submit").click();
}
document.getElementById('timer').innerHTML =
    m + ":" + s;
console.log(m)
setTimeout(startTimer, 1000000);
}

    function checkSecond(sec) {
        if (sec < 10 && sec >= 0) {sec = "0" + sec}; // add zero in front of numbers < 10
    if (sec < 0) {sec = "59"};
    return sec;
}


