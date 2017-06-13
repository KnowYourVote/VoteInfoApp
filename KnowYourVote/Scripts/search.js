var loc;
var state;

function initAutocomplete() {
    // Create the search box and link it to the UI element.
    var input = document.getElementById('pac-input');
    var searchBox = new google.maps.places.SearchBox(input);

    searchBox.addListener('places_changed', function () {
        var places = searchBox.getPlaces();

        if (places.length == 0) { return; }

        // For each place, get the icon, name and location.
        places.forEach(function (place) {
            if (!place.geometry) {
                console.log("Returned place contains no geometry");
                return;
            }
        });
        loc = encodeURI(places[0].formatted_address.replace(/,/g, ''));

        if (/.. (\d){5}, USA/.test(places[0].formatted_address)) {
            state = /.. (\d){5}/.exec(places[0].formatted_address)[0].substr(0, 2).toLowerCase();
        }
        if (/.., USA/.test(places[0].formatted_address)) {
            state = /.., USA/.exec(places[0].formatted_address)[0].substr(0, 2).toLowerCase();
        }
    });
}

$(document).ready(function () {
    $("#pac-input").keypress(function (e) {
        if (e.which == 13) {
            searchResult();
            return false;
        }
    });

    $("#search").click(function () {
        searchResult();
    });

    function searchResult() {
        var locLink = "https://www.googleapis.com/civicinfo/v2/representatives?key=AIzaSyBRTWesCWcZoIiBVFxanm3BPBkUmOdSbW8&address=" + loc;
        $.get(locLink, function (response) {
            console.log(response);
            document.getElementById('official-container').innerHTML = '';
            var id = 0;
            for (var x = 0; x < response.offices.length; x++) {
                for (var y = 0; y < response.offices[x].officialIndices.length; y++) {
                    document.getElementById('official-container').innerHTML +=
                    '<a href="' + response.officials[id].urls + '" target="blank_" class="thumbnail">' +
                        '<h4>' + response.officials[id].name + '</h4>' +
                        '<p>Position: ' + response.offices[x].name + '</p>' +
                        '<p>Party: ' + response.officials[id].party + '</p>' +
                    '</a>';
                    id++;
                }
            }
        });
        $.get("https://www.googleapis.com/civicinfo/v2/elections?key=AIzaSyBRTWesCWcZoIiBVFxanm3BPBkUmOdSbW8", function (response) {
            //console.log(response);
            var stateRegex = new RegExp("state:" + state);
            document.getElementById('election-container').innerHTML = '';
            response.elections.forEach(function (entry) {
                if (!/state:/.test(entry.ocdDivisionId) || stateRegex.test(entry.ocdDivisionId)) {
                    //console.log(entry);
                    document.getElementById('election-container').innerHTML +=
                    '<div class="cell">' + entry.name + ' at ' + entry.electionDay + '</div>';
                }
            });
        });
    }
});