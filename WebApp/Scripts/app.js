window.addEventListener('load', () => {
    let lon;
    let lat;
    let temperaturDesription = document.querySelector('.temperature-description');
    let temperaturDegree = document.querySelector('.temperature-degree');
    let locationTimezone = document.querySelector('.location-timezone');
    let iconElement = document.querySelector('.icon');
    let temperaturSection = document.querySelector('.temperature')
    let temperaturespan = document.querySelector('.temperature span')
    let temperatureh2 = document.querySelector('.temperature h2')
    var a = "03d";
    var b = "03n";
    var c = "04d";
    var e = "04n";
    var d = "50d";
    var f = "02d";



    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(position => {
            lon = position.coords.longitude;
            lat = position.coords.latitude;
            const key = "541a10ecdbf9acece04932bc25c3916e";


            let api = `https://api.openweathermap.org/data/2.5/weather?lat=${lat}&lon=${lon}&appid=${key}`



            fetch(api)
                .then(response => {


                    return response.json();
                })
                .then(data => {

                    const { temp } = data.main;
                    const { description } = data.weather[0];
                    const { icon } = data.weather[0];

                    const { name } = data;



                    console.log(a);

                    console.log(icon);
                    console.log(data);
                    if (icon == a) {

                        document.getElementById("icon").style.display = "inline";
                    }
                    if (icon == b) {

                        document.getElementById("icon2").style.display = "inline";
                    }
                    if (icon == c) {

                        document.getElementById("icon3").style.display = "inline";
                    }
                    if (icon == d) {

                        document.getElementById("icon4").style.display = "inline";
                       
                    }
                    if (icon == e) {

                        document.getElementById("icon5").style.display = "inline";
                    }
                    if (icon == f) {

                        document.getElementById("icon6").style.display = "inline";
                    }



                    /* const {main} = data.weather;*/
                    //Set DOM Elements from the API
                    temperaturDegree.textContent = Math.round(temp - 273, 5) + "C°";
                    temperaturDesription.textContent = description;
                    locationTimezone.textContent = name;


                    temperaturSection.addEventListener('click', () => {
                        if (temperaturespan.textContent == "C°") {
                            temperaturespan.textContent = "F";
                            temperatureh2.textContent = Math.round(temp) + " " + "F";
                        } else {
                            temperaturespan.textContent = "C°";
                            temperatureh2.textContent = Math.round(temp - 273, 5) + "C°";
                        }

                    });





                })
        });

    }





});