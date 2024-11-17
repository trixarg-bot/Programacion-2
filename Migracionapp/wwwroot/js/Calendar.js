let calendar;
let dotNetReference;

window.initializeCalendar = function (element, events) {
    calendar = new FullCalendar.Calendar(element, {
        initialView: 'dayGridMonth',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        events: events.map(mapEvent),
        editable: true,
        selectable: true,
        eventClick: function(info) {
            const event = {
                id: parseInt(info.event.id),
                title: info.event.title,
                description: info.event.extendedProps.description,
                startDate: info.event.start,
                endDate: info.event.end || info.event.start,
                color: info.event.backgroundColor
            };
            dotNetReference.invokeMethodAsync('OnEventClick', event);
        },
        eventDrop: function(info) {
            // Manejar el arrastre de eventos aquí si lo deseas
        }
    });

    calendar.render();
};

window.updateCalendar = function (events) {
    calendar.removeAllEvents();
    calendar.addEventSource(events.map(mapEvent));
};

function mapEvent(event) {
    return {
        id: event.id,
        title: event.title,
        description: event.description,
        start: event.startDate, // Fecha de inicio, que será la fecha de registro
        end: event.endDate,
        backgroundColor: event.color,
        borderColor: event.color
    };
}
