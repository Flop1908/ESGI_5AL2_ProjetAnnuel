//
//  MasterSecondViewController.h
//  Anne&DocTique
//
//  Created by Kapi on 13/04/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import "MasterViewController.h"

@interface MasterSecondViewController :UITableViewController //<NSFetchedResultsControllerDelegate>
{
    NSMutableArray *Anecdotes;
    NSMutableArray *AnecdotesDetail;
    NSMutableSet *Voteplus;
    NSMutableSet *Votemoins;
}

@end

//
//  MasterViewController.h
//  Anne&DocTique
//
//  Created by Kapi on 13/04/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//
/*
#import <UIKit/UIKit.h>

#import <CoreData/CoreData.h>

@interface MasterViewController : UITableViewController //<NSFetchedResultsControllerDelegate>
{
    NSMutableArray *mySources;
    NSMutableArray *adressesSources;
}
@property (strong, nonatomic) NSFetchedResultsController *fetchedResultsController;
@property (strong, nonatomic) NSManagedObjectContext *managedObjectContext;

@end
*/
