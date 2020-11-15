
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
                    var Updatebtn = "<a  onclick='UpdateCourse(" + data + ")' class='btn btn-outline-primary d-inline-block'><i class='fa fa-edit'></i></a>";
                    var Deletebtn = "<form onclick='DeleteCourse(" + data + ")' class='d-inline-block'><button type='submit' class='btn btn-outline-danger' onclick='return DeleteCourse(" + data + ")'><i class='fa fa-trash'></i> </button> </form>";

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
        },
        error: function (response) {
        }
    })


});

$(document).ready(function () {

    $.ajax({
        type: "POST",
        url: "/UserAccount/UserCounts",
        success: function (response) {
            document.getElementById("UserCounts").innerHTML = response.data;
        },
        failure: function (response) {
        },
        error: function (response) {
        }
    })
});

$(document).ready(function () {

    $.ajax({
        type: "POST",
        url: "/UserAccount/AdminCounts",
        success: function (response) {
            document.getElementById("AdminCounts").innerHTML = response.data;
        },
        failure: function (response) {
        },
        error: function (response) {
        }
    })


});



$(document).ready(function () {
    var courseId = document.getElementById("courseIdInExamDatatable").value;
    dataTable = $('#GetAllExamsDataTablesforUser').DataTable({
        "ajax": {
            "url": "/Exam/GetAllExamsDataTables?courseId=" + courseId,
            "type": 'GEt',
            "datatype": 'json'
        },
        //"stateSave": "true",
        "columns": [

            { "data": "name" },
            { "data": "startDate" },
            { "data": "endDate" },
            { "data": "duration" },
            {
                "data": "id",
                "render": function (data) {
                    btn = '<a href="/TakeExam/TakeExam?examId= ' + data + '" class="btn  p-0 m-0">شرکت در ازمون </a >'
                    return btn
                }
            }
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Persian.json"
        },
        "lengthChange": true,
        //"aLengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        autoWidth: true

    })
})


$(document).ready(function () {
    var courseId = document.getElementById("courseIdInExamDatatable").value;
    dataTable = $('#GetAllExamsDataTablesforAdmin').DataTable({
        "ajax": {
            "url": "/Exam/GetAllExamsDataTables?courseId=" + courseId,
            "type": 'GEt',
            "datatype": 'json'
        },
        //"stateSave": "true",
        "columns": [

            { "data": "name" },
            { "data": "startDate" },
            { "data": "endDate" },
            { "data": "duration" },
            {
                "data": "id",
                "render": function (data) {
                    btnQuestion = '<a style="color: #a679ff;" href="/ExamQuestion/Index?examId=' + data + '" class="btn p-0 m-0">لیست سوال ها </a >'


                    return btnQuestion
                }
            },
            {
                "data": "id",
                
                "render": function (data) {
                    btnEdit = '<a href="/Exam/Update?courseId=' + courseId + '&examId=' + data + '" class="btn btn-outline-primary"><i class="fa fa-edit" ></i ></a >'
                    btnDelete = '<a href="/Exam/Delete?courseId=' + courseId + '&id=' + data + '" class="btn btn-outline-danger" style="margin-right: 5px; " ><i class="fa fa-trash" ></i ></a >'

                    return btnEdit + btnDelete
                }
            }
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Persian.json"
        },
        "lengthChange": true,
        //"aLengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        autoWidth: true,
        responsive: true,


    })
})
$(document).ready(function () {

    dataTable = $('#allCourseDataTableForAdmin').DataTable({
        "ajax": {
            "url": "/Course/GetAllCourseDataTable",
            "type": 'GET',
            "datatype": 'json'
        },
        //"stateSave": "true",
        "columns": [

            { "data": "name" },
            {
                "data": "description",
               
            },
            {
                'className': "wraps",
                "data": "id",
                "render": function (data) {
                    exambtn = '<a href="/Exam/Index?courseId=' + data + '" class="">لیست آزمون</a >'
                    return exambtn
                }
            },
            {
                'className': "wraps",
                "data": "id",
                "render": function (data) {
                    blogbtn = '<a href="/Blog/Index?courseId=' + data + '" class="">لیست بلاگ ها</a >',
                        createblogbtn = '  <a href="/Blog/Create?courseId=' + data + '" class="">ایجاد بلاگ </a >'

                    return blogbtn + createblogbtn
                }
            },
            {
                'className': "wraps",
                "data": "id",
                "render": function (data) {
                    btnEdit = '<a href="/Course/Update?id=' + data + '" class="btn btn-outline-primary"><i class="fa fa-edit" ></i ></a >'
                    btnDelete = '<a href="/Course/Delete?id=' + data + '" class="btn btn-outline-danger" style="margin-right: 5px; " ><i class="fa fa-trash" ></i ></a >'
                    return btnEdit + btnDelete
                }
                
            }
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Persian.json"
        },
        "lengthChange": true,
        //"aLengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        autoWidth: true,
        responsive: true,

    })
})


$(document).ready(function () {

    dataTable = $('#allCourseDataTableForUser').DataTable({
        "ajax": {
            "url": "/Course/GetAllCourseDataTable",
            "type": 'GET',
            "datatype": 'json'
        },
        //"stateSave": "true",
        "columns": [

            { "data": "name" },
            {
                "data": "description",
            },
            {
                'className': "wraps",
                "data": "id",
                "render": function (data) {
                    exambtn = '<a href="/Exam/Index?courseId=' + data + '" class="">لیست آزمون</a >'
                    return exambtn
                }
            },
            {
                'className': "wraps",
                "data": "id",
                "render": function (data) {
                    blogbtn = '<a href="/Blog/Index?courseId=' + data + '" class="">لیست بلاگ ها</a >'

                    return blogbtn
                }
            }
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Persian.json"
        },
        "lengthChange": true,
        //"aLengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        autoWidth: true,
        responsive: true,

    })
})





$(document).ready(function () {

    dataTable = $('#adminsDataTable').DataTable({
        "ajax": {
            "url": "/UserAccount/AdminsDataTable",
            "type": 'GET',
            "datatype": 'json'
        },
        //"stateSave": "true",
        "columns": [

            { "data": "userName" },
            { "data": "email" }
        ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.10.21/i18n/Persian.json"
        },
        "lengthChange": true,
        //"aLengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        autoWidth: true
    })
})

function deleteQuestions(id, examId) {

    $.ajax({
        type: "POST",
        url: "/ExamQuestion/Delete?id=" + id + "&examId=" + examId,
        success: function (response) {
            location.reload();
        },
        failure: function (response) {
        },
        error: function (response) {

        }
    })

};



function radiobtn(checkbox) {
    console.log(checkbox.className)
    if (checkbox.checked == true) {
        $("." + checkbox.className).each(function () {
            this.checked = false;
        });
        checkbox.checked = true
    }
}