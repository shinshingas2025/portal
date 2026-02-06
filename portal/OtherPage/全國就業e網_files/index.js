function fnAction(todo) {
    switch (todo) {
        case "QUERY_JOBS":
            
            if (main_form.job_item_code1.value == "") {
                main_form.job_item_name1.value = "請選擇...";
            }

            frmAction.city11.value = main_form.city1.value;
            frmAction.job_item_code1.value = main_form.job_item_code1.value;
            frmAction.education_code.value = main_form.education_code1.value;
            if (main_form.txtKeySearch.value==""){
            }else{
               if (!main_form.SearchTarget[0].checked && !main_form.SearchTarget[1].checked){
                   alert("對不起! 請選擇查公司或查職務。");
                   return false;
               }
            }

            if (main_form.SearchTarget[0].checked) {
                frmAction.txtCompanyName.value = main_form.txtKeySearch.value;
                frmAction.txtJobDetail.value ="";
            }
            if (main_form.SearchTarget[1].checked) {
                frmAction.txtJobDetail.value = main_form.txtKeySearch.value;
                frmAction.txtCompanyName.value ="";
            }
            
            if (main_form.city1.value == "" && main_form.education_code1.value =="0" && main_form.job_item_code1.value == "" && frmAction.txtJobDetail.value=="" && frmAction.txtCompanyName.value=="") {
                alert("對不起! 至少要有一項搜尋條件，請重新選擇。");
                return false;
            }

            new_win_job("");
            frmAction.target = "WIN_JOB";
            //frmAction.action = "query/query_all.php";
            frmAction.action = "finejob/researchjob/list.php";
            frmAction.submit();
            break;
        case "QUERY_LABORS":
            if (main_form.job_item_code2.value == "") {
                main_form.job_item_name2.value = "請選擇...";
            }

            frmAction.city_value.value = main_form.city2.value;
            frmAction.job_item_code1.value = main_form.job_item_code2.value;
            frmAction.education_code.value = main_form.education_code2.value;

            if (main_form.city2.value == "" && main_form.education_code2.value =="0" && main_form.job_item_code2.value == "") {
                alert("對不起! 至少要有一項搜尋條件，請重新選擇。");
                return false;
            }

            new_win_labor("");
            frmAction.target = "WIN_LABOR";
            //frmAction.action = "query/query_man_all.php";
            frmAction.action = "finepepole/researchpepole/list.php";
            frmAction.submit();
            break;
    }
}
