window.downloadFileFromStream = async (fileName, contentStreamRef) => {
    const arrayBuffer = await contentStreamRef.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);

    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? 'download';
    anchorElement.click();

    URL.revokeObjectURL(url);
};