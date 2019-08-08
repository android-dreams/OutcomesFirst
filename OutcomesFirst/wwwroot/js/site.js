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
