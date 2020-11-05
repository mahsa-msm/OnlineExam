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

    $(document).ready(function () {

        dataTable = $('#resultForUserTable').DataTable({
            "ajax": {
                "url": "/TakeExam/ExamResultsForUser",
                "type": 'GET',
                "datatype": 'json'
            },
            //"stateSave": "true",
            "columns": [

                { "data": "examName" },
                { "data": "courseName" },
                { "data": "score" },
                { "data": "dateTime" }
            ],
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Persian.json"
            },
            "lengthChange": true,
            //"aLengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
            autoWidth: true
        });
});


    $(document).ready(function () {

        dataTable = $('#resultForAdminTable').DataTable({
            "ajax": {
                "url": "/TakeExam/AllExamResultsForAdminDataTable",
                "type": 'GET',
                "datatype": 'json'
            },
            //"stateSave": "true",
            "columns": [
                { "data": "userName" },
                { "data": "examName" },
                { "data": "courseName" },
                { "data": "score" },
                { "data": "dateTime" }
            ],
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Persian.json"
            },
            "lengthChange": true,
            //"aLengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
            autoWidth: true
        });
});

$(document).ready(function () {

    $.ajax({
        type: "POST",
        url: "/TakeExam/ExamsCountForAdmin",
        success: function (response) {
            document.getElementById("ExamCounts").innerHTML = response.data;
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    })


});

function loadAllExamDataTable(courseId) {

        dataTable = $('#GetAllExamsDataTables').DataTable({
            "ajax": {
                "url": "/Exam/GetAllExamsDataTables?courseId="+courseId,
                "type": 'GEt',
                "datatype": 'json'
            },
            //"stateSave": "true",
            "columns": [
                { "data": "name" },
                { "data": "startDate" },
                { "data": "endDate" },
                { "data": "duration" },
                {}
            ],
            "language": {
                "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Persian.json"
            },
            "lengthChange": true,
            //"aLengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
            autoWidth: true
        });
 
}
    





