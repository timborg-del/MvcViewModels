
function findById(event, urlHelper) {
    
    event.preventDefault();
    const anchorElement = event.target;
    const inputIdValue = $("#personIdInput").val();

    $.get(anchorElement.attributes.href.value + "/" + inputIdValue, function (result) {

       $('#' + anchorElement.attributes["data-target"].value).html(result);

    }).fail(function () {
        alert("Person with this Id: " + inputIdValue + " was not found");
    });
};

function GetCreatePersonForm(urlToCreateForm)
{
    const createBtn = $("#btn-person-create");


    $.get(urlToCreateForm, function (result)
    {
        createBtn.replaceWith(result);

    })


}


function GetDeletePersonForm(urlToDelete) {
    let personiddelete = urlToDelete.replaceAll("/", "-");
               //"PersonDeleteListDiv2-/Home/Delete/1"
    let theDiv = "#PersonDeleteListDiv2-" + personiddelete;
    console.log(urlToDelete);
    const DeleteBtn = $(theDiv);

   // alert(urlToDelete + "MY ID TO DELETE: " + personiddelete);
    
    //alert("You really want to Delete?")
    $.get(urlToDelete, function (result) {
        console.log(DeleteBtn);
        DeleteBtn.replaceWith(result);
    })


}
function PostDeletePersonForm(event, Delete) {
    event.preventDefault();
    //console.log("Create Form post:", createForm);
    event.preventDefault();

    //console.log("action url:", createForm.action);
    //console.log("form value brand:", createForm.Brand.value);

    $.post(Delete.action,
        {
            Id: Delete.Id.value,
            Name: Delete.Name.value,
            PhoneNumber: Delete.PhoneNumber.value,
            City: Delete.City.value,
        },
        function (data, status) {
            $("#PersonDeleteListDiv").html(data); //document.getElementById("createCarDiv").innerHTML = createBtn;

        }).fail(function (badForm) {
            //console.log("badForm: ", badForm);
            $("#createPersonDiv").html(badForm.responseText);
        });

}

function GetEditPersonForm(urlToEditForm) {
    const EditBtn = $("#timsdiv");
    console.log(urlToEditForm);
    alert("Hello")
    


    $.get(urlToEditForm, function (result) {
        EditBtn.replaceWith(result);
        alert(result);
    })
}

function PostCreatePersonForm(event, createForm) {
    event.preventDefault();
    //console.log("Create Form post:", createForm);
    event.preventDefault();

    //console.log("action url:", createForm.action);
    //console.log("form value brand:", createForm.Brand.value);

    $.post(createForm.action,
        {
           //Id: createForm.Id.value,
            Name: createForm.Name.value,
            PhoneNumber: createForm.PhoneNumber.value,
            City: createForm.City.value,
        },
    
        function (data, status) {
            $("#PersonListDiv").append(data);
            //$("#createPersonDiv").html(createBtn); //document.getElementById("createCarDiv").innerHTML = createBtn;

        }).fail(function (badForm) {
            //console.log("badForm: ", badForm);
            $("#createPersonDiv").html(badForm.responseText);
        });

}

function PostEditPersonForm(event, createForm) {
    event.preventDefault();
    //console.log("Create Form post:", createForm);
    event.preventDefault();

    //console.log("action url:", createForm.action);
    //console.log("form value brand:", createForm.Brand.value);

    $.post(createForm.action,
        {
            Id: createForm.Id.value,
            Name: createForm.Name.value,
            PhoneNumber: createForm.PhoneNumber.value,
            City: createForm.City.value,
        },
        function (data, status) {
            $("#timsdiv").html(data); //document.getElementById("createCarDiv").innerHTML = createBtn;

        }).fail(function (badForm) {
            //console.log("badForm: ", badForm);
            $("#createPersonDiv").html(badForm.responseText);
        });

}