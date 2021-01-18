export class FetchParams {
  constructor (startRow, fetchCount, filter, sortBy, descending) {
    this.startRow = startRow
    this.fetchCount = fetchCount
    this.filter = filter
    this.sortBy = sortBy
    this.descending = descending
  }
}
export class Filter {
  constructor (startDate, endDate, defectIds, meltNumber) {
    this.startDate = startDate
    this.endDate = endDate
    this.defectIds = defectIds
    this.meltNumber = meltNumber
  }
}
export class Pagination {
  constructor (sortBy, descending, page, rowsPerPage, rowsNumber) {
    this.sortBy = sortBy
    this.descending = descending
    this.page = page
    this.rowsPerPage = rowsPerPage
    this.rowsNumber = rowsNumber
  }
}

export class User {
  constructor () {
    this.firstName = ''
    this.lastName = ''
    this.username = ''
    this.role = ''
    this.password = ''
    this.isActive = true
  }
}

export class BusDriver {
  constructor () {
    this.name = ''
    this.surname = ''
    this.patronymic = ''
    this.documentSerialNumber = ''
    this.documentNumber = ''
    this.phoneNumber = ''
    this.isActive = true
  }
}
