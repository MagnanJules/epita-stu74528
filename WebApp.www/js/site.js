$(function () {

    setup();

});

function setup() {
    console.log('Jquery is loaded');

    LoadUserProfiles()
}

function LoadUserProfiles() {

    const url = 'https://localhost:7033/api/v1/UserProfile';

    // async method
    $.getJSON(url, function (userprofiledata) {

        console.log(userprofiledata);

        RenderDataAsTable(userprofiledata)

    });

}

function RenderDataAsTable(data) {


    let htmlString = [];

    for(const profile of data) {

        const {name, governmentId, ...rest} = profile;


        htmlString.push("<tr>");
       
        htmlString.push(`<td>${name}</td>`);
        htmlString.push(`<td>${governmentId}</td>`);
        
        htmlString.push("</tr>");
    }
    $('tbody#TableOfUserProfiles').append(htmlString.join(''));
}