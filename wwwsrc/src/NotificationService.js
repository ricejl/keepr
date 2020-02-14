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

  static async viewKeep(title = "See Keep", keepData) {
    try {
      Swal.fire({
        title: keepData.name,
        text: keepData.description,
        imageUrl: keepData.img,
        imageAlt: "Keep image"
      });
    } catch (error) {
      return false;
    }
  }

  static async verifyAction(title = "Action") {
    return Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!"
    })
      .then(result => {
        return result.value ? true : false;
      })
      .catch(error => {
        console.log(error);
      });
  }
}
