
document.getElementById('add_report').style.display = 'block';
document.getElementById('LatestReports').style.display = 'none';
document.getElementById('AddVehicle').style.display = 'none';
document.getElementById('addDriverInfor').style.display = 'none';
document.getElementById('ARDetail').style.display = 'none';

function addreport(addReport, latestReport, unconfirmedReports, titlePage) {
      
    addReport = document.getElementById('add_report');
    latestReport = document.getElementById('LatestReports');
    unconfirmedReports = document.getElementById('UnconfirmedReports');

    titlePage = document.getElementById('title_page');

    el_id2 = document.getElementById('data_managerInputs');

    if(addReport.style.display !== 'none'){
        addReport.style.display = 'none';
        latestReport.style.display = 'block';
        titlePage.InnerHTML = 'Latest Report';
    }else{
        addReport.style.display = 'block';
        latestReport.style.display = 'none';
        unconfirmedReports.style.display = 'none';
        titlePage.InnerHTML = 'Add Report';
    };

    data_managerInputs(el_id2);
   
};

function addVehicle(el_veh, el_drv) {

    el_veh = document.getElementById('AddVehicle');
    el_drv = document.getElementById('AddDriverInfor');

    if (el_drv.style.display !== 'none') {
        el_veh.style.display = 'block';
        el_drv.style.display = 'none';
    } else {
        // el_veh.style.display = 'none';
        // el_drv.style.display = 'none';
    }
};



function addDriverInfor(el_veh, el_drv) {

    el_veh = document.getElementById('AddVehicle');
    el_drv = document.getElementById('AddDriverInfor');

    if (el_veh.style.display !== 'none') {
        el_drv.style.display = 'block';
        el_veh.style.display = 'none';
    } else {
        // el_id.style.display = 'block';
        // el_drv.style.display = 'none'
    }
};

function data_managerInputs(el_id) {

    el_id = document.getElementById('data_managerInputs');

    var fields = [...el_id.getElementsByTagName('input')];

    var fields2 = [...el_id.getElementsByTagName('select')];
    
    var fields3 = [...el_id.getElementsByTagName('textarea')];
  
    const allFields = fields.concat(fields2, fields3);

    for (var i = 0; i < allFields.length; i++) {       
        allFields[i].disabled = false;        
    }

};

function EnabAll(el_id) {

    el_id = document.getElementById('data_managerInputs');

    var fields = [...el_id.getElementsByTagName('input')];

    var fields2 = [...el_id.getElementsByTagName('select')];
    
    var fields3 = [...el_id.getElementsByTagName('textarea')];
  
    const allFields = fields.concat(fields2, fields3);

    for (var i = 0; i < allFields.length; i++) {       
        allFields[i].disabled = false;        
    }

};

 function del(){
     swal({
         title: "Are you sure?",
         text: "Reports deleted cannot be recovered",
         type: "warning",
         showCancelButton: true,
         confirmButtonColor: "#DD6B55",
         confirmButtonText: "Yes, delete report!",
         cancelButtonText: "No, cancel!",
         closeOnConfirm: false,
         closeOnCancel: false
     },
         function (isConfirm) {
             if (isConfirm) {
                 document.getElementById('frm1').submit();
                 swal("Deleted!", "Selected report has been deleted.", "success");
             } else {
                 swal("Cancelled", "Report not deleted:)", "error");
             }
         });  
     
};
    
function delUser(){
    swal({
        title: "Are you sure?",
        text: "Are you sure you want to delete this user?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete user!",
        cancelButtonText: "No, cancel!",
        closeOnConfirm: false,
        closeOnCancel: false
    },
        function (isConfirm) {
            if (isConfirm) {
                document.getElementById('frm1').submit();
                swal("Deleted!", "Selected user deleted.", "success");
            } else {
                swal("Cancelled", "user not deleted:)", "error");
            }
        });    
     
}

document.getElementById('ARDetail').style.display = 'none';

function showARDetail(el){
    el.style.display = 'block';
};

function ReportDetails(rep_detail) {

    swal({
        title: "Report Details",
        text: rep_detail,
        type: "info",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Okay",
        closeOnConfirm: false
           
    });   
     
}

function getReportDetail(el) {
   
     swal({
        title: "Report Details",
        text: el.getAttribute('value'),
        type: "info",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Okay",
         closeOnConfirm: false,
        html: true
           
    });  
   
};


function ReportComplete() {
    
    swal({
        title: "<small>Accident Report Submitted</small>!",
        text: "<h3>Your accident report has been submitted for data review </h3><br /><span style=\"color: #222E3C\">Next, you will receive notification via E-mail"
            + " once review is complete</span> <br />"
            + "<a type=\"button\" style=\"text-decoration:none;\" href=\"/AccidentReport/LatestAccidents\" role=\"button\" tabindex=\"0\" class=\"SwalBtn1 customSwalBtn\">" + "Done" + "</a>",
        type: "success",
        html: true,
        showCancelButton: false,
        showConfirmButton: false,
        allowOutsideClick: false
        });
}

function ReportAdded(msg) {

    swal({
        title: "Report Added",
        text: msg,
        type: "success",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Okay",
        closeOnConfirm: false
           
    });   
}

function ReportAddError(tit,msg) {

    swal({
        title: tit ,
        text: "<h3>Please correct the following fields: </h3><br />" + msg,
        type: "error",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Okay",
        closeOnConfirm: false,
        html: true
           
    });   
}

function SectionAdd(tit,msg) {

    swal({
        title: tit ,
        text: "<h3>Completing Your Report... </h3><br />" + msg,
        type: "success",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Okay",
        closeOnConfirm: false,
        html: true
           
    });   
}

function SectionEdit(tit,msg) {

    swal({
        title: tit+"<hr />",
        text: "<h3>" +msg+"</h3><br />"
            + "<a type=\"button\" class=\"btn btn-md btn-success\" style=\"text-decoration:none;\" href=\"/AccidentReport/LatestAccidents\" role=\"button\" tabindex=\"0\" class=\"SwalBtn1 customSwalBtn\">" + "Latest Accidents" + "</a>",
            // + "<a type=\"button\" class=\"btn btn-secondary\" style=\"text-decoration:none;\" href=\"#\" role=\"button\" tabindex=\"0\" class=\"SwalBtn1 customSwalBtn\">" + "Okay" + "</a>",
        type: "success",
        showConfirmButton: false,
        closeOnConfirm: false,
        showCancelButton: false,
        confirmButtonColor: "#222E3C",
        confirmButtonText: "<span class=\"btn btn-md btn-secondary\">Close</span>",
        html: true           
    });   
}

//Admin - User Control
function UserAdded() {
    
    swal({
        title: "<small>New Data Manager added</small>!",
        text: "<h3>User with role: Data Manager, created successfully </h3><br /><span style=\"color: #222E3C\">"
            + "</span> <br />",
            // + "<a type=\"button\" style=\"text-decoration:none;\" href=\"/AccidentReport/LatestAccidents\" role=\"button\" tabindex=\"0\" class=\"SwalBtn1 customSwalBtn\">" + "Reports" + "</a>"
            // + "<a type=\"button\" style=\"text-decoration:none;\" href=\"#\" role=\"button\" tabindex=\"0\" class=\"SwalBtn1 customSwalBtn\">" + "Done" + "</a>",
        type: "success",
        html: true,
        showCancelButton: false,
        showConfirmButton: true,
        allowOutsideClick: false
        });
}

function ReportConfirmed(tit, msg) {
    
    swal({
        title:tit+"<hr />",
        text: "<h3>" +msg+"</h3><br />"
            + "<h3>The respective officers will be notified.</h3><br /><span style=\"color: #222E3C\">"
            + "</span> <br />"
            + "<a type=\"button\" class=\"btn btn-md btn-success\" style=\"text-decoration:none;\" href=\"/AccidentReport/LatestAccidents\" role=\"button\" tabindex=\"0\" class=\"SwalBtn1 customSwalBtn\">" + "Latest Accidents" + "</a>",
            // + "<a type=\"button\" class=\"btn btn-secondary\" style=\"text-decoration:none;\" href=\"AccidentReport/Add\" role=\"button\" tabindex=\"0\" class=\"SwalBtn1 customSwalBtn\">" + "Close" + "</a>",
        type: "success",
        html: true,
        closeOnConfirm: false,
        showCancelButton: false,
        showConfirmButton: false,
        allowOutsideClick: false,
        confirmButtonColor: "#222E3C",
        confirmButtonText: "<span class=\"btn btn-md btn-secondary\">Close</span>",
    });
    
}

// Fetch all the forms we want to apply custom Bootstrap validation styles to
function validatedNew() {
     
 
    const forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('click', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            form.classList.add('was-validated')
        }, false)
      
    });
}




