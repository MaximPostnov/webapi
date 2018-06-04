// Получение всех классификаций и типов
function GetClassifications() {
    $.ajax({
        url: '/api/classifications',
        type: 'GET',
        contentType: "application/json",
        success: function (classifications) {
            $.each(classifications, function (index, classification) {
                //var ulT = "<li><a href='linkc1.html'>Суп-харчо</a></li>";
                //$.each(classification.type, function (index, T) {
                //    ulT += liT(T);
                //})


                // добавляем полученные элементы в таблицу
                $(".menuBar").append("<li><a href='api/classifications/" + classification.classificationId + "'>" + classification.name + "</a><ul class='menuBar_" + classification.classificationId + "'></ul > </li>");
            })

        }
    });
}

// Получение всех типов
function GetTypes() {
    $.ajax({
        url: '/api/types',
        type: 'GET',
        contentType: "application/json",
        success: function (types) {
            $.each(types, function (index, Ty) {
                $(".menuBar_" + Ty.classificationId).append("<li><a href='api/types/" + Ty.typeId + "'>" + Ty.name + "</a></li>");
            })
        }
    });
}

// создание строки для меню
var liT = function (T) {
    return "<li><a href='linkc1.html'>Суп-харчо</a></li>" //"<li><a href='linkc1.html'>"+ T.name +"</a></li>";
}


GetClassifications();
GetTypes();