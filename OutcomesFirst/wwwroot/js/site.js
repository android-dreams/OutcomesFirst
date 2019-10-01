$(function () {
    $("#datepicker").datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        yearRange: "-100:-18",
        onSelect: function (selected) {
            //Get the Selected date from your DatePicker here
            var dob = new Date(selected);

            //Get the todays date here
            var today = new Date();

            //calculate the age value
            var diff = today.getFullYear() - dob.getFullYear();

            //Assign the age value here
            $('#age').val(diff);
        }
    });
});

function changeColour(value) {
    var color = document.body.style.backgroundColor;
    switch (value) {
        case 'r':
            color = "green";
            break;
        case 'g':
            color = "red";
            break;
    }
    document.body.style.backgroundColor = color;
}


function CalcAgeOnLeaving(birth, leavingdate) {
         
   

    var nowyear = leavingdate.getFullYear();
    var nowmonth = leavingdate.getMonth();
    var nowday = leavingdate.getDate();

    var birthyear = birth.getFullYear();
    var birthmonth = birth.getMonth();
    var birthday = birth.getDate();

    var age = nowyear - birthyear;
    var age_month = nowmonth - birthmonth;
    var age_day = nowday - birthday;

    if (age_month < 0 || (age_month === 0 && age_day < 0)) {
        age = parseInt(age) - 1;
    }
    alert(age);

    alert(age);
    if ((age === 18 && age_month <= 0 && age_day <= 0) || age < 18) {
        alert("You are " + age)
    }
    else {
        alert("You have crossed your 18th birthday !");
    }
}

function myFunction(birthdate,leavingdate) {

    alert("In myFunction");

    alert("Birthdate is " + birthdate);

   
    var nowyear = leavingdate.getFullYear();
    //var nowmonth = leavingdate.getMonth();
    //var nowday = leavingdate.getDate();


    alert("Year is " + nowyear);
    //alert("Month is " + nowmonth);
    //alert("Day is " + nowday);






   // alert(birthdate + "dates" + leavingdate);
}


