//
//  MasterViewController.h
//  Anne4Doctique
//
//  Created by Kapi on 21/06/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//

#import <UIKit/UIKit.h>

#import <CoreData/CoreData.h>

typedef enum {
	AnneEntryTypeRecent,
    AnneEntryTypeVDM,
	AnneEntryTypeCNF,
	AnneEntryTypeDTC
} AnneEntryType;

@interface MasterViewController : UITableViewController <NSFetchedResultsControllerDelegate>{
NSMutableArray *entries;
 
}
@property (strong, nonatomic) NSFetchedResultsController *fetchedResultsController;
@property (strong, nonatomic) NSManagedObjectContext *managedObjectContext;
@property (strong,nonatomic) NSString *jsonUrl;

@end
