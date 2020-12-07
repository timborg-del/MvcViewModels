
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
    console.log(DeleteBtn);

    if (confirm('Are you sure you want To Delete?')) {
        $.get(urlToDelete, function (result) {

            DeleteBtn.replaceWith(result);
        })
        console.log('Thing was saved to the database.');
    } else {
        return;
        console.log('Thing was not saved to the database.');
    }
    



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
            $("#PersonDeleteListDiv").html(data); 

        }).fail(function (badForm) {
            //console.log("badForm: ", badForm);
            $("#createPersonDiv").html(badForm.responseText);
        });

}

function GetEditPersonForm(urlToEditForm) {
    let personidelete = urlToEditForm.replaceAll("/", "-");
    let person = personidelete.replaceAll("CreateEditForm", "Delete" );
    let idOfDiv = "#PersonDeleteListDiv2-" + person;
    const EditBtn = $(idOfDiv);
    console.log(urlToEditForm);
    alert(idOfDiv);
    


    $.get(urlToEditForm, function (result) {
        EditBtn.html(result);
        console.log("getEditReturn", result)
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
            Id: createForm.Id.value,
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
            var idOfDiv = "#EditId" + createForm.Id.value;
            var theDiv = $(idOfDiv);
            theDiv.html(data);  // this is like replaceAll

        }).fail(function (badForm) {
            console.log("badForm: ", badForm);
            $("#createPersonDiv").html(badForm.responseText);
        });

}