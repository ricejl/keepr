import Swal from "sweetalert2";
export default class NotificationService {
  static async inputData(title = "Enter inputs", currentKeep) {
    try {
      const { value: formValues } = await Swal.fire({
        title,
        html:
          `<form>` +
          `<label class="mb-0" for="name">Title</label>` +
          `<input id="name" class="swal2-input" value="${currentKeep.name ||
            ""}" placeholder="Title">` +
          `<label class="mb-0" for="description">Description</label>` +
          `<input id="description" class="swal2-input" value="${currentKeep.description ||
            ""}" placeholder="Description">` +
          `<label class="mb-0" for="img">Image URL</label>` +
          `<input id="img" class="swal2-input" value="${currentKeep.img ||
            ""}" placeholder="Enter image url">` +
          `</form>`,
        focusConfirm: false,
        preConfirm: () => {
          let name = document.getElementById("name").value;
          let description = document.getElementById("description").value;
          let img = document.getElementById("img").value;
          if (!name || !description || !img) {
            Swal.showValidationMessage("Please fill out all fields");
          }
          return [name, description, img];
        }
      });
      if (formValues) {
        return {
          name: formValues[0],
          description: formValues[1],
          img: formValues[2]
        };
      }
    } catch (error) {
      return false;
    }
  }
}
