// 如果不同一台, 則改此 DOMAIN
BALLOT_DOMAIN = "http://event.ejob.sun.net.tw";

function OpenNamedWin(url,winname, w, h) {
  var wL = (screen.width-w)/2;
  var wT = (screen.height-h)/2;
  popWin = window.open(url,winname,"width="+w+",height="+h+",resizable=yes,toolbar=no,location=no,directories=no,status=no,menubar=no,copyhistory=no,scrollbars=yes");
  popWin.moveTo(wL, wT);	// 將視窗居中
}


function cal(frm){
  themeid=frm.themeid.value;
  sele=frm.sele.value;
  if(sele==0){
    var i=0;
    var itemid=0;
    while(i<frm.itemid.length){
      if(frm.itemid[i].checked){
        itemid=frm.itemid[i].value;break;
      }
      i++;
    }
    window.open(BALLOT_DOMAIN + "/hotchat/hothot.php?themeid="+themeid+"&itemid="+itemid+"&sele="+sele,"","width=440,height=260,resizable,scrollbars,status","_blank");
  }else{
     var i=0;var allitem='';var j=1;
     while(i < frm.elements.length){
       if(frm.elements[i].name.indexOf('itemid')!=-1){
         if(frm.elements[i].checked){
           allitem += "&"+frm.elements[i].name+j+"="+frm.elements[i].value;
		 j++;
	 }
       }
       i++;
     }
     window.open(BALLOT_DOMAIN + "/hotchat/hothot.php?themeid="+themeid+allitem+"&sele="+sele,"","width=440,height=260,resizable,scrollbars,status","_blank");
   }
}

function cab(frm){
  themeid=frm.themeid.value;
  window.open(BALLOT_DOMAIN + "/hotchat/hothot.php?themeid="+themeid,"","width=440,height=260,resizable,scrollbars,status","_blank");
}