

document.getElementById('add_report').style.display = 'none';

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
            function(isConfirm){
            if (isConfirm) {
                document.getElementById('frm1').submit();
                swal("Deleted!", "Selected report has been deleted.", "success");
            } else {
                swal("Cancelled", "Report not deleted:)", "error");
            }
        })
       
     
    }
