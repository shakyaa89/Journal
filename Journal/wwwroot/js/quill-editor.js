let quill;

window.initQuill = (editorId, toolbarId) => {
    quill = new Quill(`#${editorId}`, {
        theme: 'snow',
        placeholder: 'Start writing your thoughts here...',
        modules: {
            toolbar: {
                container: `#${toolbarId}`
            }
        }
    });
};

window.getQuillContent = () => {
    return quill ? quill.root.innerHTML : "";
};

window.setQuillHtml = (html) => {
    if (quill) {
        quill.root.innerHTML = html ?? "";
    }
};
