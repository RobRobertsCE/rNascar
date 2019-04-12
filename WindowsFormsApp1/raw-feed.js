//***** TODO ****
    // BRING IN STAINLESS FONT CALL
//***** END TODO *****

var startLapArray=[];

function createRawFeed(liveFeedData,liveFlagData){
    $('.rf-leaders tbody').empty();
    $('#pqrLeaders tbody').empty();
    $('#pqrLeadChanges tbody').empty();
    $('#pqrCautionsStatistic tbody').empty();
    console.log("generating live data");

    $(".runName").html(liveFeedData.run_name);
    $(".trackName").html(liveFeedData.track_name);

    var lapNumber = liveFeedData["lap_number"];
    var lapsToGo = liveFeedData["laps_to_go"];

    var seriesID = liveFeedData.series_id;

    if(seriesID==1){
        $(".seriesLogo").attr("src","//www.nascar.com/wp-content/uploads/sites/7/2018/06/monsterLogo70x35_rightrail.png");
    }
    if(seriesID==2){
        $(".seriesLogo").attr("src","//www.nascar.com/wp-content/uploads/sites/7/2018/08/NXS_logos_updated.png");
    }
    if(seriesID==3){
        $(".seriesLogo").attr("src","//www.nascar.com/wp-content/uploads/sites/7/2018/12/NGOTS-Logo-3-70x35.png");
    }

    var flagState = liveFeedData["flag_state"];

    if(flagState==="0"){
        flagState="9";
    }

    var flagText="GREEN";
    switch(flagState){
        case 1:
            flagText="GREEN";
            break;
        case 2:
            flagText="CAUTION";
            break;
        case 3:
            flagText="RED";
            break;
        case 4:
            flagText="CHECKERED";
            break;
        case 8:
            flagText="WARM";
            break;
        case 9:
            flagText="NOT ACTIVE";
            break;
        default:
            flagText="GREEN";
    }
    $(".flag-text").html(flagText);

    $(".leaderboard-status-image").attr("src","/wp-content/plugins/raw-feed/images/rf-"+flagState+".png");

    var averageSpeed = 0;
    if (liveFeedData["vehicles"]) {
        averageSpeed = liveFeedData["vehicles"]["average_speed"];
    }

    $(".lap_number").html(lapNumber);
    $(".laps_to_go").html(lapsToGo);

    var cars = liveFeedData["vehicles"];
    var average_speed=0;
    var last_speed=0;
    var last_lap_speed=0;
    var carsCount=0;

    var elapsed_time_secs = new Date(null);
    elapsed_time_secs.setSeconds(liveFeedData["elapsed_time"]);
    var elapsed_time = elapsed_time_secs.toISOString().substr(11, 8);
    $(".elapsed_time").html(elapsed_time);

    if(cars && cars.length){
        for (var i = 0, len = cars.length; i < len; i++) {
            average_speed += cars[i]["average_speed"];
            last_lap_speed = cars[i]["last_lap_speed"];
            if(last_lap_speed > last_speed){
                last_speed = cars[i]["last_lap_speed"];
            }
            carsCount++;
        }
    }

    average_speed = average_speed / carsCount;
    average_speed = Math.round(average_speed * 100) / 100;
    $(".average_speed").html(average_speed+"0");
    $(".last_speed").html(last_speed);

    createDriverTable(cars);
    createCautionsTable(liveFlagData);

    var sortedLaps = [];
    for (var i = 0, len = startLapArray.length; i < len; i++) {
        var runningStartLap = startLapArray[i][0];
        sortedLaps[runningStartLap] = startLapArray[i];
    }
    sortedLaps = sortedLaps.filter(function(val){return val});
    for (var s = 0, length =  sortedLaps.length; s < length; s++){
        try{
            createLeadChangesTable(sortedLaps[s][0],sortedLaps[s][1],sortedLaps[s][2],sortedLaps[s][3]);
        }
        catch(err){
            console.log(err);
        }
    }

}

function createDriverTable(cars){
    var sortedCars = [];
    if (cars && cars.length) {
        for (var i = 0, len = cars.length; i < len; i++) {
            var currentRow = cars[i];
            var runningPosition = cars[i]["running_position"];
            var carNum = currentRow.vehicle_number;

            sortedCars[runningPosition] = cars[i];
            var lapsLed = currentRow.laps_led;

            createLeadersTable(lapsLed,carNum);
        }
    }

    for(var s = 0, sorlen = sortedCars.length; s < sorlen; s++){
        try{
            var currentRow = sortedCars[s];
            var driverName = currentRow.driver.full_name;
            var position = currentRow.running_position;
            var carNum = currentRow.vehicle_number;
            var manu = currentRow.vehicle_manufacturer;
            var delta = currentRow.delta;
            if(delta=="0.0"){
                delta="--";
            }
            else{
                if(delta<0){
                    delta = parseInt(delta/1);
                }
                else{
                    delta = delta.toFixed(3);
                }
            }
            var laps = currentRow.laps_completed;
            var lastLap = currentRow.last_lap_speed;
            var bestTime = currentRow.best_lap_time;
            var bestSpeed = currentRow.best_lap_speed;
            var bestLap = currentRow.best_lap;

            var tableRow = '<tr role="row" class="odd">';
                tableRow += '<td class="position position sorting_1">'+position+'</td>';
                tableRow += '<td class="car car">'+carNum+'</td>';
                tableRow += '<td class="driver driver">'+driverName+'</td>';
                tableRow += '<td class="manuf car-make"><img src="/wp-content/plugins/raw-feed/images/logo-'+manu+'.png" /></td>';
                tableRow += '<td class="delta delta">'+delta+'</td>';
                tableRow += '<td class="laps laps">'+laps+'</td>';
                tableRow += '<td class="last-lap last-lap">'+lastLap.toFixed(3)+'</td>';
                tableRow += '<td class="best-time best-time">'+bestTime.toFixed(3)+'</td>';
                tableRow += '<td class="best-speed best-speed">'+bestSpeed.toFixed(3)+'</td>';
                tableRow += '<td class="best-lap best-lap">'+bestLap+'</td>';
                tableRow += '</tr>';
            $('.rf-leaders tbody').append(tableRow);
        }
        catch(err){
        }
    }
}
function createLeadersTable(lapsLed,carNum){
    var totalLapsLed=0;
    var leadersTotalLapsLed=0;
    var numTimesLed=0;
    for (var i = 0, len = lapsLed.length; i < len; i++) {
        var currentRow = lapsLed[i];
        var startLap = currentRow.start_lap;
        var endLap = currentRow.end_lap;
        if(endLap==startLap){
            totalLapsLed = 1;
            leadersTotalLapsLed += 1;
        }
        else{
            totalLapsLed = (endLap+1) - startLap;
            leadersTotalLapsLed += (endLap+1) - startLap;
        }
        numTimesLed++;
        startLapArray.push([startLap,endLap,totalLapsLed,carNum]);
    }
    if(numTimesLed>0){
        var tableRow = '<tr class="odd">';
            tableRow += '<td class="car">'+carNum+'</td>';
            tableRow += '<td class="times">'+numTimesLed+'</td>';
            tableRow += '<td class="laps">'+leadersTotalLapsLed+'</td>';
            tableRow += '</tr>';
        $('#pqrLeaders tbody').append(tableRow);
    }
}
function createLeadChangesTable(startLap,endLap,totalLapsLed,carNum){
    var tableRow = '<tr class="odd">';
        tableRow += '<td class="car">'+carNum+'</td>';
        tableRow += '<td class="start">'+startLap+'</td>';
        tableRow += '<td class="end">'+endLap+'</td>';
        tableRow += '<td class="total">'+totalLapsLed+'</td>';
        tableRow += '</tr>';
    $('#pqrLeadChanges tbody').append(tableRow);

}
var cautionCount=1;
function createCautionsTable(cautions){
    cautionCount=1;
    for (var i = 0, len = cautions.length; i < len; i++) {
        var currentRow = cautions[i];
        var lapNumber = currentRow.lap_number;
        var flagState = currentRow.flag_state;
        var elapsedTime = currentRow.elapsed_time;
        var comment = currentRow.comment;
        if (comment == null){
            comment="";
        }
        var beneficiary = currentRow.beneficiary;
        if (beneficiary == null){
            beneficiary="";
        }
        var timeOfDay = currentRow.time_of_day;

        var tableRow = '<tr class="even">';
            tableRow += '<td style="width:40px">'+cautionCount+'</td>';
            tableRow += '<td style="width:50px">'+lapNumber+'</td>';
            tableRow += '<td>'+beneficiary+'</td>';
            tableRow += '<td>'+comment+'</td>';
            tableRow += '</tr>';

            if(flagState===2){
                $('#pqrCautionsStatistic tbody').append(tableRow);
                cautionCount++
            }
    }
}