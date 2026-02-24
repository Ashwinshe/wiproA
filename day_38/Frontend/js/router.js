// Responsible for loading different views inside SPA.
// It injects HTML content into the main #app container.
export function loadView(viewHtml) {
    // Get reference to main container
    const appContainer = document.getElementById("content");
    // Replace existing content
    appContainer.innerHTML = viewHtml;
}
//# sourceMappingURL=router.js.map