// site.js

// DOM manipulation
const busTable = document.getElementById('busTable');

// Event listeners
busTable.addEventListener('click', (event) => {
	if (event.target.tagName === 'BUTTON') {
		// Handle button clicks (e.g., book, cancel, etc.)
		const busId = event.target.dataset.busId;
		// Make AJAX request to book or cancel a bus
		fetch(`/api/Bookings/Book/${busId}`)
			.then((response) => response.json())
			.then((data) => {
				// Handle response and update UI
				console.log(data);
				// Update the table or display a message
			})
			.catch((error) => console.error('Error:', error));
	}
});

// Form validation
const bookingForm = document.getElementById('bookingForm');

bookingForm.addEventListener('submit', (event) => {
	event.preventDefault();

	// Validate form fields
	const busId = document.getElementById('BusId').value;
	const userId = document.getElementById('UserId').value;
	const totalFare = document.getElementById('TotalFare').value;

	if (!busId || !userId || !totalFare) {
		alert('Please fill in all required fields.');
		return;
	}

	// Submit the form using AJAX
	const formData = new FormData(bookingForm);
	fetch('/api/Bookings', {
		method: 'POST',
		body: formData,
	})
		.then((response) => response.json())
		.then((data) => {
			// Handle response and redirect or display a message
			console.log(data);
			window.location.href = '/Bookings';
		})
		.catch((error) => console.error('Error:', error));
});
