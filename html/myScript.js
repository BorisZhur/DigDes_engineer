
var x = new XMLHttpRequest();

function myGet(){
	//document.write(x.responseText)
	var data = JSON.parse(x.responseText)
	//document.write(typeof data)
	var temp = document.getElementById("temp")
	
	if ((x.status!=200)&&(x.status!=201)&&(x.status!=202))
	{
		temp.innerHTML = "error"
	}
	else
	{
		temp.innerHTML = data.main.temp
	}
}

function myScriptFunc (){
	
	x.open("GET", "http://api.openweathermap.org/data/2.5/weather?id=524901&appid=6385d1369c67c03f03328a1a63a2f5a1&units=metric", true);
	//x.open("GET", "http://api.openweathermap.org/data/2.5/weather?id=524901&appid=6385d&units=metric", true);
	
		x.onload = myGet;
	
	
	x.send();
}
setInterval(myScriptFunc,10000)
function myScriptFuncOnClick(){
	x.open("GET", "http://api.openweathermap.org/data/2.5/weather?id=524901&appid=6385d1369c67c03f03328a1a63a2f5a1&units=metric", true);
	//x.open("GET", "http://api.openweathermap.org/data/2.5/weather?id=524901&appid=6385d&units=metric", true);
	
		x.onload = myGet;
	
	
	x.send();
}