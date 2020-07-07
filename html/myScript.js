var x = new XMLHttpRequest();
x.open("GET", "http://api.openweathermap.org/data/2.5/weather?id=524901&appid=6385d1369c67c03f03328a1a63a2f5a1&units=metric", true);
x.onload = function myGet(){
    alert("get");
	//document.write(x.responseText)
	var data = JSON.parse(x.responseText)
	//document.write(typeof data)
	var temp = document.getElementById("temp")
	temp.innerHTML = data.main.temp
	setTimeout(myGet,10000)
}
x.send(null);
