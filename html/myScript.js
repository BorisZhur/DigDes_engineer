


function myScriptFunc (){
	var x = new XMLHttpRequest();
	x.open("GET", "http://api.openweathermap.org/data/2.5/weather?id=524901&appid=6385d1369c67c03f03328a1a63a2f5a1&units=metric", true);

	
		x.onload = function (){
			
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
	
	
	x.send();
}
setInterval(myScriptFunc,10000)
function myScriptFuncOnClick(){
	var y = new XMLHttpRequest();
	y.open("GET", "http://api.openweathermap.org/data/2.5/weather?id=524901&appid=6385d1369c67c03f03328a1a63a2f5a1&units=metric", true);
	
		y.onload = function (){
			
			//document.write(x.responseText)
			var data = JSON.parse(y.responseText)
			//document.write(typeof data)
			var temp = document.getElementById("temp")
			
			if ((y.status!=200)&&(y.status!=201)&&(y.status!=202))
			{
				temp.innerHTML = "error"
			}
			else
			{
				temp.innerHTML = data.main.temp
			}				
			
		}
	y.send();
}