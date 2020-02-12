import Swal from "sweetalert2";
export default class NotificationService {
  static async inputData(title = "Enter inputs", currentKeep) {
    try {
      const { value: formValues } = await Swal.fire({
        title,
        html:
          `<form>` +
          `<label class="mb-0" for="name-edit">Title</label>` +
          `<input id="name-edit" class="swal2-input" value="${currentKeep.name ||
            ""}" placeholder="Title">` +
          `<label class="mb-0" for="description-edit">Description</label>` +
          `<input id="description-edit" class="swal2-input" value="${currentKeep.description ||
            ""}" placeholder="Description">` +
          `<label class="mb-0" for="img-edit">Image URL</label>` +
          `<input id="img-edit" class="swal2-input" value="${currentKeep.img ||
            ""}" placeholder="Enter image url">` +
          `</form>`,
        focusConfirm: false,
        preConfirm: () => {
          // @ts-ignore
          let name = document.getElementById("name-edit").value;
          // @ts-ignore
          let description = document.getElementById("description-edit").value;
          // @ts-ignore
          let img = document.getElementById("img-edit").value;
          //   if (!name || !description || !img) {
          //     Swal.showValidationMessage("Please fill out all fields");
          //   }
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