// global request and XML document objects
var req;

// retrieve XML document (reusable generic function);
// parameter is URL string (relative or complete) to
// an .xml file whose Content-Type is a valid XML
// type, such as text/xml; XML source must be from
// same domain as HTML file
function loadXMLDoc(url) {	
    // branch for native XMLHttpRequest object
    if (window.XMLHttpRequest) {
        req = new XMLHttpRequest();
        req.onreadystatechange = processReqChange;
        req.open("GET", url, true);
        req.send(null);
    // branch for IE/Windows ActiveX version
    } else if (window.ActiveXObject) {
        //isIE = true;
        req = new ActiveXObject("Microsoft.XMLHTTP");
        if (req) {
            req.onreadystatechange = processReqChange;
            req.open("GET", url, true);
            req.send();
        }
    }
}

// handle onreadystatechange event of req object
function processReqChange(){
	// only if req shows "complete"
	if (req.readyState == 4) {
		// only if "OK"
		//alert(req.status)		
		if (req.status == 200) {		
			//alert(req.responseText.substring(req.responseText.indexOf('<div>')))			
			// ...processing statements go here...
			response  = req.responseXML.documentElement;

			method =
				response.getElementsByTagName('method')[0].firstChild.data;
			
			//result = response.getElementsByTagName('result')[0].firstChild.data;
			var start = req.responseText.indexOf('<result>') + 8
			var stop = req.responseText.indexOf('</result>')
			result = req.responseText.substring(start,stop);

			eval(method + '(\'\', result)');
		} else {
			alert("There was a problem retrieving the XML data:\n" + req.statusText);
		}
	}
}		