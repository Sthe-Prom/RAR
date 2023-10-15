

var firstTime = localStorage.getItem("first_time");

if(!firstTime) {
    window.onload = function() {
        document.getElementById('add_report').style.display = 'none';        
    };
    localStorage.setItem("first_time","1");
}

document.getElementById('AddVehicle').style.display = 'none';
document.getElementById('addDriverInfor').style.display = 'none';
document.getElementById('ARDetail').style.display = 'none';

function addreport(addReport, latestReport, unconfirmedReports) {
      
    addReport = document.getElementById('add_report');
    latestReport = document.getElementById('LatestReports');
    unconfirmedReports = document.getElementById('UnconfirmedReports');

    el_id2 = document.getElementById('data_managerInputs');

    if(addReport.style.display !== 'none'){
        addReport.style.display = 'none';
        latestReport.style.display = 'block';
        unconfirmedReports.style.display = 'block';
    }else{
        addReport.style.display = 'block';
        latestReport.style.display = 'none';
        unconfirmedReports.style.display = 'none';
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

    // var AccDet = el.getAttribute('value');
    
    // el = AccDet + 1;
    // var PVContainer = document.getElementById(AccDet).value;
    // alert(PVContainer);

    // if(PVContainer.style.display !== 'none'){
    //     PVContainer.style.display = 'none';        
    // }else{
    //     PVContainer.style.display = 'block';        
    // };
    
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
            + "<a type=\"button\" style=\"text-decoration:none;\" href=\"/AccidentReport/AddReport\" role=\"button\" tabindex=\"0\" class=\"SwalBtn1 customSwalBtn\">" + "Done" + "</a>",
        type: "success",
        html: true,
        showCancelButton: false,
        showConfirmButton: false
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


