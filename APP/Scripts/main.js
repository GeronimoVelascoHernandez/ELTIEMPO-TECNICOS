
var urlBack = "http://localhost:44339/Tecnico/"
// Declarar array global que contendra la lista de elementos
var arrElements = []
var arrEditElements = []
//LLamar función de jquery para acción click del botón addElement
$(".addElement").click(function (e) {
	//Deshabilitar el envio por Http
	e.preventDefault()
	let idElement = $("#element").val()
	let nameElement = $("#element option:selected").text()
	let cantidad = $("#cantidad").val()
	if (idElement != '' && cantidad != '') {
		if (typeof existElement(idElement) === 'undefined') {
			//agregar elemento al array
			arrElements.push({
				'idElemento': idElement,
				'elemento': nameElement,
				cantidad
			})
		} else {
			alert("El elemento ya se encuentra seleccionado")
		}
		// Metodo para mostrar en Html el array de los elementos
		showElements()
	} else {
		alert("Debe Seleccionar un elemento con la cantidad");
	}
});

$(".editElement").click(function (e) {
	//Deshabilitar el envio por Http
	e.preventDefault()
	let idElement = $("#edit-element").val()
	let nameElement = $("#edit-element option:selected").text()
	let cantidad = $("#edit-cantidad").val()
	if (idElement != '' && cantidad != '') {
		if (typeof existEditElement(idElement) === 'undefined') {
			//agregar elemento al array
			arrEditElements.push({
				 'idElemento': idElement,
				'elemento': nameElement,
				 cantidad
			})
		} else {
			alert("El elemento ya se encuentra seleccionado")
		}
		// Metodo para mostrar en Html el array de los elementos
			showEditElements()
	} else {
		alert("Debe Seleccionar un elemento con la cantidad");
	}
});



function existElement(idElement) {
	let existElement = arrElements.find(function (element) {
		return element.idElemento == idElement
	})
	return existElement
}

function existEditElement(idElement) {
	let existElement = arrEditElements.find(function (element) {
		return element.idElemento == idElement
	})
	return existElement
}

function showElements() {
	$("#list-elements").empty();

	arrElements.forEach(function (element) {
		$("#list-elements").append('<div class="form-group"><span> ' + element.elemento + ' - ' + element.cantidad + ' </span><button onclick="removeElement(' + element.idElemento + ')" class="btn btn-danger">X </button></div>')
	})
}

function showEditElements() {
	$("#list-edit-elements").empty();

	arrEditElements.forEach(function (element) {
		$("#list-edit-elements").append('<div class="form-group"><span> ' + element.elemento + ' - ' + element.cantidad + ' </span><button onclick="removeEditElement(' + element.idElemento + ')" class="btn btn-danger">X </button></div>')
	})
}

function removeElement(idElement) {
	let index = arrElements.indexOf(existElement(idElement))
	arrElements.splice(index, 1)
	showElements()
	console.log(arrElements)
}

function removeEditElement(idElement) {
	let index = arrEditElements.indexOf(existElement(idElement))
	arrEditElements.splice(index, 1)
	showEditElements()
	console.log(arrElements)
}

//Generar el metodo de envio al backend
$(".CreateButtonModal").click(function (e) {
	//Deshabilitar el envio por Http
	e.preventDefault()


	if ($("#idTecnico").valid() &&
			$("#nombre").valid() &&
			$("#salario").valid() &&
			$("#cantidad").valid() &&
			$("#IdSucursal").valid() &&
			$("#element").valid() &&
			arrElements != null
	) {
		let url = urlBack + "Create"
		let tecnico = {
			idTecnico: $("#idTecnico").val(),
			nombre: $("#nombre").val(),
			salario: $("#salario").val(),
			IdSucursal: $("#IdSucursal").val(),
			sucursal: $("#IdSucursal option:selected").text(),
			cantidadElementos: 0,
			elements: arrElements
		}

		//metodo post usando ajax para enviar la información al backend
		$.post(url, tecnico, function (response) {
			//Respuesta del Request
			if (response.code == 'false') {
				alert("Verifique que el codigo no este repetido y que ingreso elementos al tecnico")
			} else {
				alert(response.msn)
				//redirección al modulo de listar tecnicos
				location.href = urlBack + "Index"
			}
		}, 'json').fail(function (error) {
			alert("Inserción Fallida")
			console.error(error)
		});
	}
	

});

$(".deleteButton").click(function (e) {

	$("#inputDeleteModal").val($(this).val());
});


$(".editButton").click(function (e) {
	$("#idTecnico_Edit").val($("#idTecnico_" + $(this).val()).val());
	$("#nombre_Edit").val($("#nombre_" + $(this).val()).val());
	$("#salario_Edit").val($("#salario_" + $(this).val()).val());
	$("#sucursal_Edit").val($("#IdSucursal_" + $(this).val()).val());
	//metodo get usando ajax para traer los elementos del tecnico
	$.get(urlBack+'Edit/'+$(this).val() , function (response) {
		//Respuesta del Request
		if (response) {
			arrEditElements = response.elements;
			showEditElements();
		} else {
			alert("Error trayendo los elementos del técnico")
		}
	}, 'json').fail(function (error) {
		alert("Proceso fallido")
		console.error(error)
	});


});

$("#EditButtonModal").click(function (e) {
	//Deshabilitar el envio por Http
	e.preventDefault()
	if ($("#idTecnico_Edit").valid() &&
		$("#nombre_Edit").valid() &&
		$("#salario_Edit").valid() &&
		$("#edit-cantidad").valid() &&
		$("#edit-element").valid() &&
		arrEditElements != null
	)  {
		let url = urlBack + "Edit"
		let params = {
			idTecnico: $("#idTecnico_Edit").val(),
			nombre: $("#nombre_Edit").val(),
			salario: $("#salario_Edit").val(),
			idSucursal: $("#sucursal_Edit").val(),
			elements: arrEditElements
		}

		//metodo post usando ajax para enviar la información al backend
		$.post(url, params, function (response) {
			//Respuesta del Request
			if (response.code == 'false') {
				alert("Debe agregar elementos al técnico")
			} else {
				alert("Actualización Satisfactoria")
				//redirección al modulo de listar tecnicos
				location.href = urlBack + "Index"
			}
		}, 'json').fail(function (error) {
			alert("Actualización Fallida")
			console.error(error)
		});
	}
	

});


$(".deleteButtonModal").click(function (e) {
	//Deshabilitar el envio por Http
	e.preventDefault()

	let url = urlBack+"Delete"
	let params = {
		id: $("#inputDeleteModal").val(),
		tecnico: []
	}

	//metodo post usando ajax para enviar la información al backend
	$.post(url, params, function (response) {
		//Respuesta del Request
		if (typeof response.code == 'undefined') {
			alert(response.message)
		} else {
			if (response.code == "true") {
				alert("Eliminación Satisfactoria")
				//redirección al modulo de listar tecnicos
				location.href = urlBack+"Index"
            }
		}
	}, 'json').fail(function (error) {
		alert("Eliminación Fallida")
		console.error(error)
	});




});

