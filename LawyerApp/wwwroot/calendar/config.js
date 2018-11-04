"use strict"

///constant objects
const fullHours = ["01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00",
    "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"];

//take Teammembers data
class Person {
    constructor(name, surname, email, accept, time, isWork) {
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.accept = accept;
        this.time = time;
        this.isWork = isWork;
    }
}

//set all times and use Person data
class Times {
    constructor(isReserved,personData) {
        this.workDay = isReserved;
        this.personData = personData;
    }
}

///use this class for ajax
class AjaxProperties{
    constructor(url,method,data){
        this.url = url;
        this.method = method;
        this.data = data;
    }
}

class Infrastructures {

    //check dates for weekdays and holidays
    static checkWeekDates(calendarSelector, selectedDate, datas, noWorkDayClass, holidayClass) {
        let elements = document.querySelectorAll(calendarSelector);
        for (let i = 0; i < elements.length; i++) {
            let count = 0;
            for (let item in datas.weekDays) {
                if (i % 7 === count && datas.weekDays[item] === "false")
                    elements[i].classList.add(noWorkDayClass);
                count++;
            }
            
            for (let item of datas.dates) {
                if (new Date(item).getDate() === parseInt(elements[i].innerText))
                    elements[i].classList.add(holidayClass);
            }
        }
    }

    // send ajax request and check dates
    static checkAndPaintDays(url,date) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                let a = JSON.parse(this.response);
                Infrastructures.checkWeekDates("#calendar_content div", date, a, "no-work", "holidaySelector");
            }
        };
        xhttp.open("GET",url, true);
        xhttp.send();
    }

    //create clocks function
    static createTable(data, selector) {
        let count = 0;
        for (let item of data) {
            count++;
            let tr = document.createElement("tr");
            //create first th element
            let tdFirst = document.createElement("th");
            tdFirst.setAttribute("scope", "row");
            tdFirst.innerText = count;
            //create second th element
            let tdSecond = document.createElement("th");
            //create third th element
            let tdThird = document.createElement("th");
            //create email th
            let tdEmail = document.createElement("th");
            //create fourth th element
            let tdFourth = document.createElement("th");
            tdFourth.innerText = item.personData.time;
            //create fifth th element and btn
            let fifth = document.createElement("th");
            let btn = document.createElement("button");
            //check teammember is work or not in this day
            if (item.workDay === true) {
                tdSecond.innerText = item.personData.name;
                tdThird.innerText = item.personData.surname;
                tdEmail.innerText = item.personData.email;
                ///check teammember is scheduled or not
                if (item.personData.isWork === true) {
                    if (item.personData.accept === true) {
                        btn.setAttribute("class", "btn btn-danger w-100 acceptTime");
                        btn.innerText = "decline";
                    } else {
                        btn.setAttribute("class", "btn btn-success w-100 acceptTime");
                        btn.innerText = "accept";
                    }
                } else {
                    btn.setAttribute("class", "btn btn-danger w-100 scheduleTime");
                    btn.innerText = "Free this time";
                }
            } else {
                let fifth = document.createElement("th");
                btn.setAttribute("class", "btn btn-default w-100 scheduleTime");
                btn.innerText = "Busy this time";
            }
            tr.appendChild(tdFirst);
            tr.appendChild(tdSecond);
            tr.appendChild(tdThird);
            tr.appendChild(tdEmail);
            tr.appendChild(tdFourth);
            fifth.appendChild(btn);
            tr.appendChild(fifth);
            document.querySelector(selector).appendChild(tr);
        }
    }

    //check teammembers day and creates dates
    static checkAndCreateTimes(dates, begin, end, reservedDates) {
            let arr = [];
            for (let item of dates) {
                let count = false;
                var obj;
                for (let item1 of reservedDates) {
                    if (item === convertDateToTimeString(item1.date)) {
                        count = true;
                        obj = new Person(item1.name, item1.surname,item1.email,item1.accept, item, item1.workDay);
                    }
                }
                if (count === true)
                    arr.push(new Times(true,obj));
                else if (parseInt(item) >= begin && parseInt(item) < end)
                    arr.push(new Times(false, new Person(null, null, null, null, item, null)));
            }
            return arr;
    }

    //create tables on user interface
    static createTablesUserInterface(data, selector) {
        let count = 0;
        let elements = document.querySelectorAll(selector);
        for (let item of data) {
            if (item.workDay === false) {
                count++;
                let span = document.createElement("span");
                span.setAttribute("class", "calendarTimes");
                span.innerText = item.personData.time;
                if (count <= 5) {
                    elements[0].appendChild(span);
                } else {
                    elements[1].appendChild(span);
                }
            }
        }
    }
}
//creates date from strings
function createDateFromString(obj) {
    let date = obj.day + obj.fullDate + " " + obj.time;
    return new Date(date).toLocaleString();
}

///create datetime string
function convertDateToTimeString(date) {
    return new Date(date).getHours()+":00";   
}




