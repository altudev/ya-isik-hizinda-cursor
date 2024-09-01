/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./index.html",
        "./src/**/*.{js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {
            colors: {
                'dark-gray': '#1a1a1a', // Siyaha yakın gri renk
            },
        },
    },
    plugins: [],
};