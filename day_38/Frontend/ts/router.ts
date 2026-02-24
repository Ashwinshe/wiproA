
// Responsible for loading different views inside SPA.
// It injects HTML content into the main #app container.
export function loadView(viewHtml: string): void {

    // Get reference to main container
    const appContainer = document.getElementById("content") as HTMLElement;

    // Replace existing content
    appContainer.innerHTML = viewHtml;
}