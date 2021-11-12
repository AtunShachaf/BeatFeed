function fetchGenres() {
    $.ajax({
        type: 'GET',
        url: '/Artists/GetGenreListAjax',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: LoadGraph1
    });
}
function fetchCities() {
    $.ajax({
        type: 'GET',
        url: '/Concerts/GetCityListAjax',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: LoadGraph2
    });
}
function LoadGraph1(res) {
    var width = 740, height = 484;
    var colors = d3.scaleOrdinal(d3.schemePaired);
    var svg = d3.select("#graph1").append("svg")
        .attr("width", width).attr("height", height);
    var data = d3.pie().sort(null).value(function (d) { return d.count; })(res);
    var i = 0;
    var segments = d3.arc()
        .innerRadius(0)
        .outerRadius(200)
        .padAngle(.05)
        .padRadius(50);
    var sections = svg.append("g").attr("transform", "translate(250,250)")
        .selectAll("path").data(data);
    sections.enter().append("path").attr("d", segments)
        .attr("fill", function (d) { return colors(++i); });
    var content = d3.select("g").selectAll("text").data(data);
    var legends = svg.append("g").attr("transform", "translate(500,100)")
        .selectAll(".legends").data(data);
    var legend = legends.enter().append("g")
        .classed("legends", true)
        .attr("transform", function (d, i) { return "translate(0," + (i + 1) * 30 + ")"; });
    legend.append("rect")
        .attr("width", 20)
        .attr("height", 20)
        .attr("fill", function (d) { return colors(++i); });
    legend.append("text")
        .text(function (d) {
            if(d.data.count == 1)
                return d.data.count + " " + d.data.Genre + " Artist";
            else
                return d.data.count + " " + d.data.Genre + " Artists";
        })
        .classed("text", true)
        .attr("x", 30)
        .attr("y", 14);
}

function LoadGraph2(details) {
    var i = 1;
    var width = 740, height = 484;
    var colors = d3.scaleOrdinal(d3.schemePaired);
    var svg = d3.select("#graph2").append("svg")
        .attr("width", width).attr("height", height);
    var data = d3.pie().sort(null).value(function (d) { return d.count; })(details);
    var segments = d3.arc()
        .innerRadius(0)
        .outerRadius(200)
        .padAngle(.05)
        .padRadius(50);
    var sections = svg.append("g").attr("transform", "translate(250,250)")
        .selectAll("path").data(data);
    sections.enter().append("path").attr("d", segments)
        .attr("fill", function (d) { return colors(i++); });
    var content = d3.select("g").selectAll("text").data(data);
    var legends = svg.append("g").attr("transform", "translate(500,100)")
        .selectAll(".legends").data(data);
    var legend = legends.enter().append("g")
        .classed("legends", true)
        .attr("transform", function (d, i) { return "translate(0," + (i + 1) * 30 + ")"; });
    legend.append("rect")
        .attr("width", 20)
        .attr("height", 20)
        .attr("fill", function (d) { return colors(i++); });
    legend.append("text")
        .text(function (d) {
            if (d.data.count>1)
                return d.data.count + " Concerts in " + d.data.city;
            return d.data.count + " Concert in " + d.data.city;
        })
        .classed("text", true)
        .attr("x", 30)
        .attr("y", 14);
}


$(document).ready(function () {
    fetchGenres();
    fetchCities();
})