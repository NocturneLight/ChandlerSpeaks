// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function DisplayEducationFilters() 
{
    // Store the education checkbox in a variable.
    const educationCheckbox = document.getElementById("GrantType_4_");

    // Store each subeducation checkbox in an array.
    const checkboxArray = [
        document.getElementById("GrantType_9_"),
        document.getElementById("GrantType_10_"),
        document.getElementById("GrantType_11_"),
        document.getElementById("GrantType_12_"),
        document.getElementById("GrantType_13_")
    ];

    // Store each subeducation label in an array.
    const labelArray = [
        document.getElementById("GrantType_9_Label"),
        document.getElementById("GrantType_10_Label"),
        document.getElementById("GrantType_11_Label"),
        document.getElementById("GrantType_12_Label"),
        document.getElementById("GrantType_13_Label")
    ];

    // Store each linebreak in an array.
    const lineBreakArray = [
        document.getElementById("GrantType_9_BR"),
        document.getElementById("GrantType_10_BR"),
        document.getElementById("GrantType_11_BR"),
        document.getElementById("GrantType_12_BR"),
        document.getElementById("GrantType_13_BR")
    ];


    // If the education checkbox is checked...
    if (educationCheckbox.checked) 
    {
        // Iterate the entire length of the checkbox, label, and linebreak
        // array.
        for (let index = 0; index < checkboxArray.length; index++) 
        {
            // Get the current element of every checkbox, label, and linebreak.
            const checkbox = checkboxArray[index];
            const label = labelArray[index];
            const linebreak = lineBreakArray[index];

            // Revert each's display style to their defaults.
            checkbox.style.display = "";
            label.style.display = "";
            linebreak.style.display = "";
        }
    } 
    // Otherwise...
    else 
    {
        // Get the current element of every checkbox, label, and linebreak.
        for (let index = 0; index < checkboxArray.length; index++) 
        {
            // Get the current element of every checkbox, label, and linebreak.
            const checkbox = checkboxArray[index];
            const label = labelArray[index];
            const linebreak = lineBreakArray[index];

            // Change each's display style to "none".
            checkbox.style.display = "none";
            label.style.display = "none";
            linebreak.style.display = "none";

            // Reset the checkbox back to false.
            checkbox.checked = false;
        }      
    }
}